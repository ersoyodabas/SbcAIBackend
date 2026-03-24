using System.Diagnostics;
using ExtensionConfigApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ExtensionCors", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

var extensionProjectPath = Path.GetFullPath(
    Path.Combine(app.Environment.ContentRootPath, "..", "..", "..", "sbcai_extension")
);
var runtimePayloadPath = Path.Combine(extensionProjectPath, "RuntimePayload");
var startupLogger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("ExtensionBuildOnStartup");

app.Lifetime.ApplicationStarted.Register(() =>
{
    _ = Task.Run(async () =>
    {
        if (!Directory.Exists(extensionProjectPath))
        {
            startupLogger.LogWarning("Extension klasoru bulunamadi: {Path}", extensionProjectPath);
            return;
        }

        try
        {
            startupLogger.LogInformation("API ayaga kalkti. Extension build baslatiliyor: {Path}", extensionProjectPath);

            var processStartInfo = new ProcessStartInfo
            {
                FileName = OperatingSystem.IsWindows() ? "npm.cmd" : "npm",
                Arguments = "run build",
                WorkingDirectory = extensionProjectPath,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = processStartInfo };
            process.OutputDataReceived += (_, eventArgs) =>
            {
                if (!string.IsNullOrWhiteSpace(eventArgs.Data))
                {
                    startupLogger.LogInformation("[extension-build] {Line}", eventArgs.Data);
                }
            };
            process.ErrorDataReceived += (_, eventArgs) =>
            {
                if (!string.IsNullOrWhiteSpace(eventArgs.Data))
                {
                    startupLogger.LogError("[extension-build] {Line}", eventArgs.Data);
                }
            };

            if (!process.Start())
            {
                startupLogger.LogError("Extension build prosesi baslatilamadi.");
                return;
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();

            if (process.ExitCode == 0)
            {
                startupLogger.LogInformation("Extension build tamamlandi.");
                return;
            }

            startupLogger.LogError("Extension build basarisiz. Exit code: {ExitCode}", process.ExitCode);
        }
        catch (Exception exception)
        {
            startupLogger.LogError(exception, "Extension build calistirilirken hata olustu.");
        }
    });
});

app.UseCors("ExtensionCors");

app.MapGet("/api/extension/runtime", () =>
{
    var html = ReadTextOrDefault(
        Path.Combine(runtimePayloadPath, "panel.html"),
        "<div class='container-fluid py-3'><div class='d-flex justify-content-between align-items-center mb-3'><h5 class='mb-0'>SBCAI Dynamic Backend UI</h5><button class='btn btn-sm btn-outline-secondary' id='close-panel'>Kapat</button></div><div class='input-group input-group-sm mb-3'><span class='input-group-text'>Ara</span><input class='form-control' id='menu-search' placeholder='menu ara' /></div><div class='row g-2' id='menu-root'><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Dashboard'>Dashboard</button></div><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Operasyon'>Operasyon</button></div><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Analiz'>Analiz</button></div><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Icerik'>Icerik</button></div><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Entegrasyon'>Entegrasyon</button></div><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Ayarlar'>Ayarlar</button></div><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Guvenlik'>Guvenlik</button></div><div class='col-12'><button class='btn btn-light border w-100 text-start menu-btn' data-menu='Yardim'>Yardim</button></div></div><div class='mt-3 small text-secondary' id='runtime-log'>Hazir</div></div>"
    );
    var css = ReadTextOrDefault(
        Path.Combine(runtimePayloadPath, "panel.css"),
        "body{margin:0;background:#f6f9ff;color:#0f172a;font-family:Segoe UI,Tahoma,sans-serif}.menu-btn{transition:all .15s ease}.menu-btn:hover{background:#e6efff}.menu-active{background:#dbeafe!important;border-color:#93c5fd!important}#runtime-log{min-height:36px}"
    );
    var script = ReadTextOrDefault(
        Path.Combine(runtimePayloadPath, "panel.js"),
        "(function(){const panelButtons=Array.from(document.querySelectorAll('.menu-btn'));const menuSearch=document.getElementById('menu-search');const runtimeLog=document.getElementById('runtime-log');const closeButton=document.getElementById('close-panel');const menuActions={Dashboard:()=>showLog('Dashboard backend event calisti'),Operasyon:()=>showLog('Operasyon backend event calisti'),Analiz:()=>showLog('Analiz backend event calisti'),Icerik:()=>showLog('Icerik backend event calisti'),Entegrasyon:()=>showLog('Entegrasyon backend event calisti'),Ayarlar:()=>showLog('Ayarlar backend event calisti'),Guvenlik:()=>showLog('Guvenlik backend event calisti'),Yardim:()=>showLog('Yardim backend event calisti')};function showLog(message){if(runtimeLog){runtimeLog.textContent=message;}}panelButtons.forEach((button)=>{button.addEventListener('click',()=>{panelButtons.forEach((x)=>x.classList.remove('menu-active'));button.classList.add('menu-active');const menuName=button.dataset.menu||'';if(menuActions[menuName]){menuActions[menuName]();}});});if(menuSearch){menuSearch.addEventListener('input',(event)=>{const text=(event.target.value||'').toLowerCase();panelButtons.forEach((button)=>{const menuName=(button.dataset.menu||'').toLowerCase();const wrapper=button.parentElement;if(wrapper){wrapper.style.display=!text||menuName.includes(text)?'block':'none';}});});}if(closeButton){closeButton.addEventListener('click',()=>{if(window.frameElement&&window.frameElement.parentElement){window.frameElement.parentElement.remove();}});}showLog('Backend script yuklendi');})();"
    );

    var response = new ExtensionRuntimeResponse
    {
        Html = html,
        Css = css,
        BootstrapCssUrl = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css",
        Script = script,
    };

    return Results.Ok(response);
});

app.MapGet("/api/health", () => Results.Ok(new { status = "ok", utc = DateTime.UtcNow }));

app.Run();

static string ReadTextOrDefault(string filePath, string fallback)
{
    return File.Exists(filePath) ? File.ReadAllText(filePath) : fallback;
}
