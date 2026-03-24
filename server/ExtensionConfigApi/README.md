# ExtensionConfigApi (.NET 9)

Bu API, Chrome extension icin dinamik panel konfigurasyonu doner.

## Calistirma

```bash
dotnet restore
dotnet run
```

`dotnet run` sonrasinda API ayaga kalkar ve hemen ardindan `sbcai_extension` klasorunde otomatik olarak `npm run build` tetiklenir.

Varsayilan endpoint:

- `GET http://localhost:5055/api/extension/config`
- `GET http://localhost:5055/api/health`

## Config JSON Sekli

```json
{
  "panelTitle": "SBCAI Remote Panel",
  "panelSubtitle": "Server tarafindan yonetilen menu",
  "sections": [
    {
      "title": "Dashboard",
      "action": {
        "type": "showAlert",
        "message": "Dashboard server config ile guncellendi."
      }
    }
  ]
}
```

## Desteklenen action.type degerleri

- `showAlert`
- `showToast`
- `openUrl`
- `callApi`
