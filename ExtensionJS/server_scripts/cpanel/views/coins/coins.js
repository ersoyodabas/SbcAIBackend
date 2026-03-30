// let myClubsJs = {
// 	data: {
// 	},
//     async run() {

//     },
//     generateMyClubsTable() {
//         let self = this;
//         let modalMyClubs = document.getElementById('modalmyclubs');
        
//         var tableMyClbs = document.getElementById('tblMyClubs');
//         if (tableMyClbs) {
//             tableMyClbs.remove();
//         }
//         modalMyClubs.classList.add('tableFixHead');


//         var htmlString = `<div class="content_box p-0"><table id="tblMyClubs" style="text-align: left;">
//                 <thead>
//                     <tr>
//                         <th > </th>
//                         <th style="text-align:left;width:500px;">${ loc.content.account}</th>
//                         <th style="text-align:left;width:500px;">${ loc.content.club_name}</th>
//                         <th >${loc.content.note}</th>

//                         <th style="text-align:center;">${loc.content.unlocked}</th>
//                         <th style="text-align:center;">${loc.content.banned}</th>
//                         <th style="text-align:center;">${loc.content.platform}</th>
//                         <th style="text-align:center;width:360px;" >${loc.content.last_update}</th>
//                         <th style="text-align:center;width:170px;">${loc.content.coin}</th>

//                         <th style="text-align:center;"></th>
//                     </tr>
//                 </thead>
//                 <tbody>`;
//         let total_coin = 0;
//         for (let index = 0; index < ls.user.user_club.filter(x=>!x.banned).length; index++) {
//             const element = ls.user.user_club[index];
//             let coin = binlik(element.club_coin);
//             total_coin += element.club_coin;

//             htmlString += `
//                         <tr class="${element.banned ? 'bannedClubRow' : ''}">
//                              <td  style="width:40px;"> <span> ${index + 1}</span> </td> 
//                              <td  style="width:110px;"> <span> <i class="fa-solid fa-user"></i> ${element.account_name ? element.account_name : ''}</span> </td> 
//                              <td  style="width:130px;"> <span> ${element.club_name}</span> </td> 
//                              <td style="width:160px;"> <input id="inputClubNote${element.club_id}" type="tel" class="numericInput customInput shortInput" style="width: 200px;" value="${element.club_note === null ? '' : element.club_note}"/> </td> 

//                       `;

//             //htmlString += "			 <td>";
//             //htmlString += "            <select id='selectClubNation" + element.club_id + "' class='customInput'   style='width:120px' >";
//             //htmlString += `                 <option value='0'>${mainJs.none}</option >`;
//             //                                for (var k = 0; k < mainJs.nation_list.length; k++) {
//             //                                    let elr = mainJs.nation_list[k];
//             //                                    htmlString += ` <option ${(element.nation_id) === (elr.id) ? 'selected' : ''} 
//             //                                                          value = '${elr.id}' ${element.nation_id == elr.id ? 'selected' : ''}> ${ls.lang === 'tr' ? elr.desc_tr : elr.desc_en}
//             //                                                    </option > `;
//             //                                }
//             //htmlString += "            </select>";
//             //htmlString += "           </td >";


//             htmlString += `			 <td style="text-align:center;width: 55px;" ><input id="inputClubUnlock${element.club_id}" type="checkbox" style="height: 18px;width: 18px;margin-top: 10px;" ${element.unlock === true ? 'checked' : ''}/> </td> 
//                              <td style="text-align:center;" ><input id="inputClubBanned${element.club_id}" type="checkbox" style="height: 18px;width: 18px;margin-top: 10px;" ${element.banned === true ? 'checked' : ''}/> </td> 
//                              <td> 
//                                 <select id="selectClubPlatform${element.club_id}" class="customInput select-platform" >
//                                     <option  ${element.platform === null ? 'selected' : ''}></option>
//                                     <option value='ps' ${element.platform === 'ps' ? 'selected' : ''}> PS </option>
//                                     <option value='xbox' ${element.platform === 'xbox' ? 'selected' : ''}> XBOX </option>
//                                     <option value='pc' ${element.platform === 'pc' ? 'selected' : ''}> PC  </option>
//                                 </select>
//                             </td>
//                             <td style="text-align:right"> ${mainJs.calcCustomTime(element.last_active_minute,loc.ago)}  </td>
//                              <td style="text-align:right" > <span> ${coin}</span> <img src="https://www.ea.com/ea-sports-fc/ultimate-team/web-app/images/coinIcon.png" alt="" style="height:15px" /> </td>
//                             <td > <i id="btnDeleteClub${element.club_id}" style="margin-left:15px;color:#ff4d4d;" class="btnDeleteClub fas fa-trash-alt"></i> </td>
//                     </tr>`;


//         }

//         htmlString += `</tbody><tfoot>
//                     <tr> <td colspan="9"><hr style="border: solid 1px #121418;"></td></tr>
                
//                                         <tr>
//                                             <td colspan="7"> </span></td> 
//                                             <td style="text-align:center" > <span>${loc.content.total}</span></td> 
//                                             <td style="text-align:right"> 
//                                                 <span> ${binlik(total_coin)}</span> 
//                                                 <img src="https://www.ea.com/ea-sports-fc/ultimate-team/web-app/images/coinIcon.png" style="height:15px" /> 
//                                             </td>
// <td> <i id="iSaveAllClubs" style="margin-left:15px;color:#3ef468;cursor:pointer;font-size:25px" class="fas fa-save"></i> </td>
//                                         </tr>
// </tfoot>
//                                     </table> </div>`;

//          modalMyClubs.insertAdjacentHTML('beforeend', htmlString);
//         document.getElementById('spanTotalCoins').innerText = binlik(total_coin);

//          this.setEventHandlers();

//     },
//     async setEventHandlers() {

//         let self = this;

//         document.querySelectorAll('.btnDeleteClub').forEach(element => {
//             element.addEventListener("click", async(event) => {

//                 //update all user clubs
//                 postParams = {};
//                 postParams.lang = ls.lang;
//                 let id = event.target.id.replace('btnDeleteClub', '');
//                 loaderShow();
//                 let res = await getData('club/deleteUserClub?id=' + id);
//                 if (res.result) {
//                     showMsg(res.message, 'positive');
//                     res = await mainJs.getUserClub();
//                     ls.user.user_club = res.data.filter(x => x.user_id === ls.user.id);
//                 } else {
//                     showMsg(res.message, 'negative');
//                 }
//                 loaderHide();


//                 await self.generateMyClubsTable();
//             });

//         });

//         //klüplerim
//         document.getElementById("iSaveAllClubs").addEventListener("click", async() => {

//             try {

//                 //let tmp_clubs = Array.from(document.querySelectorAll('#tblMyClubs>tbody>tr'));
//                 //futLog(document.querySelector('#tblMyClubs').outerHTML);


//                 let tmp_list = [];


//                 for (let index = 0; index < ls.user.user_club.length; index++) {
//                     const element = ls.user.user_club[index];
//                     tmp_list.push({
//                         id: element.club_id,
//                         create_date: element.club_create_date,
//                         user_id: ls.user.id,
//                         name: element.club_name,
//                         coin: element.club_coin,
//                         platform: document.getElementById('selectClubPlatform' + (element.club_id)).value,
//                         note: document.getElementById('inputClubNote' + (element.club_id)).value,
//                         unlock: document.getElementById('inputClubUnlock' + (element.club_id)).checked,
//                         banned: document.getElementById('inputClubBanned' + (element.club_id)).checked,
//                         user :{ "name": "", "email": "", "lang_app": "", "password": "", "payment_type_char": "" }
//                         //nation_id: document.getElementById('selectClubNation' + (element.club_id)).value,
//                     });
//                 }

//                 //update all user clubs
//                 //postParams = {};
//                 //postParams.lang = ls.lang;
//                 //postParams.data = tmp_list;
//                 loaderShow();
//                 let res = await postData('club/updateUserClubs', tmp_list);
//                 if (res.result) {
//                     res = await mainJs.getUserClub();
//                     ls.user.user_club = res.data.filter(x => x.user_id === ls.user.id);
//                     await self.generateMyClubsTable();

//                 }
//                 showMsg('Saved', 'positive');


//             } catch (error) {
//                 showMsg(error, 'negative');
//             } finally {
//                 loaderHide();
//             }


//         });

//         document.


//         document.getElementById("inputAutoBidSleepDuration").addEventListener("change", event => {
//             ls.menu_settings.auto_bid.next_tour_sleep_duration = event.target.value;
//             mainJs.updateLs()
//         });
//         // document.getElementById("inputAddWonItemsToTransferMarket").addEventListener("change", event => {
//         //     ls.menu_settings.auto_bid.add_won_items_to_transfer_market = event.target.checked;
//         //     mainJs.updateLs()
//         // });
//         document.getElementById("inputAddWonItemsToTransferList").addEventListener("change", event => {
//             ls.menu_settings.auto_bid.add_won_items_to_transfer_list = event.target.checked;
//             mainJs.updateLs()
//         });

//         document.getElementById("inputAddWonItemsToClub").addEventListener("change", event => {
//             ls.menu_settings.auto_bid.add_won_items_to_club = event.target.checked;
//             mainJs.updateLs()
//         });
//     },
//     async mounted(){
//         let xz = await mainJs.getUserClub();
//         ls.user.user_club = xz.data;
//         await this.generateMyClubsTable();
//     }
// };
