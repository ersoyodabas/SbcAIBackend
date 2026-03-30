//#region TOP MENU BUTTONS
        // document.getElementById("tMarketUnsoldMenu").addEventListener("click", event => {

        //     document.getElementById('tMarketAvailableMenu').classList.remove('selected');
        //     document.getElementById('tMarketUnsoldMenu').classList.add('selected');

        //     document.getElementById('tmarket-unsold-container').hidden = false;
        //     document.getElementById('tmarket-available-container').hidden = true;
        // });
        // document.getElementById("tMarketAvailableMenu").addEventListener("click", event => {

        //     document.getElementById('tMarketUnsoldMenu').classList.remove('selected');
        //     document.getElementById('tMarketAvailableMenu').classList.add('selected');


        //     document.getElementById('tmarket-unsold-container').hidden = true;
        //     document.getElementById('tmarket-available-container').hidden = false;
        // });
        //#endregion

        //#region RELIST 
        //quicksell settings
        // document.getElementById("inputReListQSActive").addEventListener("click", event => {
        //     ms.tmarket_relist_qs_active = event.target.checked;

        //     //Max. Rating
        //     document.getElementById('inputReListQSMaxRating').value = null;
        //     ms.tmarket_relist_qs_max_rating_tradeable = null;

        //     //Lowest Price
        //     document.getElementById('inputReListQSIfMinPrice').checked = false;
        //     ms.tmarket_relist_qs_if_min_price = false;

        //     //Chemistry
        //     document.getElementById('inputReListQSChemistry').checked = ms.tmarket_relist_qs_active;
        //     ms.tmarket_relist_qs_chemistry = ms.tmarket_relist_qs_active;

        //     //Manager
        //     document.getElementById('inputReListQSManager').checked = ms.tmarket_relist_qs_active;
        //     ms.tmarket_relist_qs_manager = ms.tmarket_relist_qs_active;

        //     //Position
        //     document.getElementById('inputReListQSPosition').checked = false;
        //     ms.tmarket_relist_qs_position = false;

        //     //Contract
        //     document.getElementById('inputReListQSContract').checked = ms.tmarket_relist_qs_active;
        //     ms.tmarket_relist_qs_contract = ms.tmarket_relist_qs_active;

        //     //Other
        //     document.getElementById('inputReListQSOther').checked = ms.tmarket_relist_qs_active;
        //     ms.tmarket_relist_qs_other = ms.tmarket_relist_qs_active;

        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListQSMaxRating").addEventListener("keyup", event => {

        //     if (!isNumeric(event.target.value)) {
        //         document.getElementById("inputReListQSMaxRating").value = null;
        //         ms.tmarket_relist_qs_max_rating_tradeable = null;

        //     } else {

        //         //Hızlı Satı Aktif ET
        //         document.getElementById('inputReListQSActive').checked = true;
        //         ms.tmarket_relist_qs_active = true;

        //         ms.tmarket_relist_qs_max_rating_tradeable = event.target.value;
        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListQSIfMinPrice").addEventListener("change", event => {
        //     ms.tmarket_relist_qs_if_min_price = event.target.checked;

        //     if (event.target.checked) {

        //         //Hızlı Satı Aktif ET
        //         document.getElementById('inputReListQSActive').checked = true;
        //         ms.tmarket_relist_qs_active = true;

        //         document.getElementById('inputReListQSMaxRating').value = null;
        //         ms.tmarket_relist_qs_max_rating_tradeable = null;

        //         // ms.tmarket_send_to_club = !event.target.checked;
        //         // document.getElementById('inputTMarketListingSendClubCommonPlayers').checked = false

        //         // ms.tmarket_send_to_club_if_min = !event.target.checked;
        //         // document.getElementById('inputTMarketLSendToClubRareCards').checked = false;

        //     }

        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListQSChemistry").addEventListener("change", event => {
        //     ms.tmarket_relist_qs_chemistry = event.target.checked;
        //     if (event.target.checked) {
        //         //Hızlı Satı Aktif ET
        //         document.getElementById('inputReListQSActive').checked = true;
        //         ms.tmarket_relist_qs_active = true;
        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListQSManager").addEventListener("change", event => {
        //     ms.tmarket_relist_qs_manager = event.target.checked;
        //     if (event.target.checked) {
        //         //Hızlı Satı Aktif ET
        //         document.getElementById('inputReListQSActive').checked = true;
        //         ms.tmarket_relist_qs_active = true;
        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListQSPosition").addEventListener("change", event => {
        //     ms.tmarket_relist_qs_position = event.target.checked;
        //     if (event.target.checked) {
        //         //Hızlı Satı Aktif ET
        //         document.getElementById('inputReListQSActive').checked = true;
        //         ms.tmarket_relist_qs_active = true;
        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListQSContract").addEventListener("change", event => {
        //     ms.tmarket_relist_qs_contract = event.target.checked;
        //     if (event.target.checked) {
        //         //Hızlı Satı Aktif ET
        //         document.getElementById('inputReListQSActive').checked = true;
        //         ms.tmarket_relist_qs_active = true;
        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListQSOther").addEventListener("change", event => {
        //     ms.tmarket_relist_qs_other = event.target.checked;
        //     if (event.target.checked) {
        //         //Hızlı Satı Aktif ET
        //         document.getElementById('inputReListQSActive').checked = true;
        //         ms.tmarket_relist_qs_active = true;
        //     }
        //     mainJs.updateUserMenuSetting();
        // });

        //send to club settings
        // document.getElementById("inputReListSendToClubActive").addEventListener("click", event => {
        //     ms.tmarket_relist_send_to_club_active = event.target.checked;

        //     if (!event.target.checked) {
        //         document.getElementById('inputReListSendToClubCommonPlayerCards').checked = false;
        //         ms.tmarket_relist_send_to_club_common_player = false;

        //         document.getElementById('inputReListSendToClubRarePlayerCards').checked = false;
        //         ms.tmarket_relist_send_to_club_rare_player = false;

        //         document.getElementById('inputReListSendToClubIfMinPrice').checked = false;
        //         ms.tmarket_relist_send_to_club_if_min_price = false;

        //         //Özel fiyatı sıfırla
        //         ms.tmarket_relist_buy_now_price = null;
        //         document.getElementById('inputReListBuyNowPrice').value = null;
        //     }


        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListSendToClubCommonPlayerCards").addEventListener("click", event => {
        //     ms.tmarket_relist_send_to_club_common_player = event.target.checked;

        //     if (event.target.checked) {
        //         document.getElementById('inputReListSendToClubActive').checked = true;
        //         ms.tmarket_relist_send_to_club_active = true;

        //         //Fiyat karşılaştırmayı kapat
        //         document.getElementById("inputReListSendToClubIfMinPrice").checked = false;
        //         ms.tmarket_relist_send_to_club_if_min_price = false;

        //         //Özel fiyatı sıfırla
        //         ms.tmarket_relist_buy_now_price = null;
        //         document.getElementById('inputReListBuyNowPrice').value = null;

        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListSendToClubRarePlayerCards").addEventListener("click", event => {
        //     ms.tmarket_relist_send_to_club_rare_player = event.target.checked;

        //     if (event.target.checked) {
        //         document.getElementById('inputReListSendToClubActive').checked = true;
        //         ms.tmarket_relist_send_to_club_active = true;

        //         //Fiyat karşılaştırmayı kapat
        //         document.getElementById("inputReListSendToClubIfMinPrice").checked = false;
        //         ms.tmarket_relist_send_to_club_if_min_price = false;

        //         //Özel fiyatı sıfırla
        //         ms.tmarket_relist_buy_now_price = null;
        //         document.getElementById('inputReListBuyNowPrice').value = null;

        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListSendToClubIfMinPrice").addEventListener("click", event => {
        //     ms.tmarket_relist_send_to_club_if_min_price = event.target.checked;

        //     if (event.target.checked) {
        //         document.getElementById('inputReListSendToClubActive').checked = true;
        //         ms.tmarket_relist_send_to_club_active = true;

        //         //Normal ve Nadirleri klübe göndermeyi iptal et
        //         document.getElementById('inputReListSendToClubCommonPlayerCards').checked = false;
        //         ms.tmarket_relist_send_to_club_common_player = false;
        //         document.getElementById('inputReListSendToClubRarePlayerCards').checked = false;
        //         ms.tmarket_relist_send_to_club_rare_player = false;

        //     }
        //     mainJs.updateUserMenuSetting();
        // });

        //list settings
        // document.getElementById("inputReListBuyNowPrice").addEventListener("keyup", event => {
        //     addLog(1256);
        //     if (!isNumeric(event.target.value)) {
        //         addLog(1258);
        //         //RAKAM GİRİLMEMİŞSE
        //         // document.getElementById("inputReListQSMaxRating").value = null;
        //         ms.tmarket_relist_buy_now_price = null;
        //         document.getElementById('inputReListBuyNowPrice').value = null;

        //     } else {
        //         ms.tmarket_relist_buy_now_price = event.target.value;

        //         document.getElementById('inputReListSComparePrice').checked = false;
        //         ms.tmarket_relist_s_compare_price = false;

        //         //Hızlı Satı Kapat

        //         // addLog(1265);          
        //         // ms.tmarket_relist_s_compare_price = event.target.value;


        //         // ms.tmarket_relist_send_to_club_if_min = false;
        //         // document.getElementById('inputRelistSendToClubIfMinPrice').checked = false;

        //         // ms.tmarket_relist_qs_if_min_price = false;
        //         // document.getElementById('inputReListQSIfMinPrice').checked = false;


        //         //quicksell
        //         if (document.getElementById('inputReListQSActive').checked) {
        //             mainJs.triggerButton('inputReListQSActive');
        //         }


        //         //send to club
        //         if (document.getElementById('inputReListSendToClubActive').checked) {
        //             mainJs.triggerButton('inputReListSendToClubActive');
        //         }


        //         ms.tmarket_relist_s_compare_price = false;
        //         document.getElementById('inputReListSComparePrice').checked = false;


        //         ms.tmarket_relist_s_price_change = 0;
        //         document.getElementById('inputReListSPriceChange').value = 0;


        //         //send to my club
        //         //KLÜBE GÖNDER AKTİF İSE
        //         // if (document.getElementById('inputReListSendToClubActive').checked) {
        //         //     mainJs.triggerButton('inputReListSendToClubActive');
        //         // }


        //         // ms.tmarket_price_change = null;
        //     }
        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("inputReListSComparePrice").addEventListener("change", event => {
        //     ms.tmarket_relist_s_compare_price = event.target.checked;



        //     if (event.target.checked) {

        //         //ÖZEL FİYATI NULLA            
        //         document.getElementById('inputReListBuyNowPrice').value = null;
        //         ms.tmarket_relist_buy_now_price = null;

        //         //Fiyat Değişimini Negatif Yap
        //         document.getElementById('inputReListSPriceChange').value = -1;
        //         ms.tmarket_relist_s_price_change = -1;

        //         //document.getElementById('inputUseCustomPrice').checked = false;
        //         //ms.tmarket_re_listing.use_custom_price = false;

        //         //document.getElementById('inputListBuyNowPrice').value = null;
        //         //ms.tmarket_custom_price = null;
        //         //document.getElementById('trCustomPrice').hidden = true;
        //     }


        //     mainJs.updateUserMenuSetting();
        // });
        // document.getElementById("lblPriceUnSoldChangeDown").addEventListener("click", event => {

        //     //ÖZEL FİYATI NULLA            
        //     document.getElementById('inputReListBuyNowPrice').value = null;
        //     ms.tmarket_relist_buy_now_price = null;

        //     let val_ = Number(document.getElementById('inputReListSPriceChange').value);
        //     addLog(1470, val_);

        //     val_--;
        //     if (val_ < -3) { return; }
        //     document.getElementById('inputReListSPriceChange').value = val_;
        //     ms.tmarket_relist_s_price_change = val_;
        //     mainJs.updateUserMenuSetting();

        //     if (val_ <= 0) {
        //         //document.getElementById('trQuickSellIfMin1').hidden = false;
        //     }

        // });
        // document.getElementById("lblUnsoldPriceChangeUp").addEventListener("click", event => {
        //     let val_ = document.getElementById('inputReListSPriceChange').value;
        //     val_++;

        //     //ÖZEL FİYATI NULLA            
        //     document.getElementById('inputReListBuyNowPrice').value = null;
        //     ms.tmarket_relist_buy_now_price = null;

        //     if (val_ > 0) {
        //         //UNSOLD SENT TO CLUB IF MINI KAPAT
        //         //  document.getElementById('inputReListSendToClubIfMinPrice').checked = false;
        //         // ms.tmarket_relist_s_price_change = val_;

        //         // //QUICK SELL IF MIN PRICE UNSOLD U KAPAT,
        //         // document.getElementById('inputReListQSIfMinPrice').checked = false;
        //         // ms.tmarket_relist_qs_if_min_price = false;

        //         // //CUSTOM PRICE I YOK ET
        //         // document.getElementById('inputReListCustomPrice').value = null;
        //         // ms.tmarket_relist_s_compare_price = null;


        //     }




        //     if (val_ > 3) { return; }

        //     document.getElementById('inputReListSPriceChange').value = val_;
        //     ms.tmarket_relist_s_price_change = val_;


        //     if (val_ >= 1) {
        //         //document.getElementById('trQuickSellIfMin1').hidden = true;
        //     }
        //     if (val_ < 0) {

        //     }

        //     mainJs.updateUserMenuSetting();
        // });
        //#endregion

        //#region LIST
        document.getElementById("inputListQSActive").addEventListener("click", event => {
            ms.tmarket_list_qs_active = event.target.checked;

            //Max. Rating
            document.getElementById('inputListQSMaxRating').value = null;
            ms.tmarket_list_qs_max_rating_tradeable = null;

            document.getElementById('inputListQSMaxRatingUntCopy').value = null;
            ms.tmarket_list_qs_max_rating_untradeable_copy = null;

            //Lowest Price
            document.getElementById('inputListQSIfMinPrice').checked = false;
            ms.tmarket_list_qs_if_min_price = false;

            //Chemistry
            document.getElementById('inputListQSChemistry').checked = ms.tmarket_list_qs_active;
            ms.tmarket_list_qs_chemistry = ms.tmarket_list_qs_active;

            //Manager
            document.getElementById('inputListQSManager').checked = ms.tmarket_list_qs_active;
            ms.tmarket_list_qs_manager = ms.tmarket_list_qs_active;

            //Position
            document.getElementById('inputListQSPosition').checked = false;
            ms.tmarket_list_qs_position = false;

            //Contract
            document.getElementById('inputListQSContract').checked = ms.tmarket_list_qs_active;
            ms.tmarket_list_qs_contract = ms.tmarket_list_qs_active;

            //Other
            document.getElementById('inputListQSOther').checked = ms.tmarket_list_qs_active;
            ms.tmarket_list_qs_other = ms.tmarket_list_qs_active;

            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSMaxRating").addEventListener("keyup", event => {

            if (!isNumeric(event.target.value)) {
                document.getElementById("inputListQSMaxRating").value = null;
                ms.tmarket_list_qs_max_rating_tradeable = null;
            } else {
                ms.tmarket_list_qs_max_rating_tradeable = event.target.value;

                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_list_qs_active = true;
            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSMaxRatingUntCopy").addEventListener("keyup", event => {

            if (!isNumeric(event.target.value)) {
                document.getElementById("inputListQSMaxRatingUntCopy").value = null;
                ms.tmarket_list_qs_max_rating_untradeable_copy = null;
            } else {
                ms.tmarket_list_qs_max_rating_untradeable_copy = event.target.value;

                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_list_qs_active = true;
            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSIfMinPrice").addEventListener("change", event => {
            ms.tmarket_list_qs_if_min_price = event.target.checked;

            if (event.target.checked) {
                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_relist_qs_active = true;

            }

            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSChemistry").addEventListener("change", event => {
            ms.tmarket_list_qs_chemistry = event.target.checked;
            if (event.target.checked) {
                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_relist_qs_active = true;
            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSManager").addEventListener("change", event => {
            ms.tmarket_list_qs_manager = event.target.checked;
            if (event.target.checked) {
                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_list_qs_active = true;
            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSPosition").addEventListener("change", event => {
            ms.tmarket_list_qs_position = event.target.checked;
            if (event.target.checked) {
                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_list_qs_active = true;
            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSContract").addEventListener("change", event => {
            ms.tmarket_list_qs_contract = event.target.checked;
            if (event.target.checked) {
                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_list_qs_active = true;
            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListQSOther").addEventListener("change", event => {
            ms.tmarket_list_qs_other = event.target.checked;
            if (event.target.checked) {
                //Hızlı Satı Aktif ET
                document.getElementById('inputListQSActive').checked = true;
                ms.tmarket_list_qs_active = true;
            }
            mainJs.updateUserMenuSetting();
        });

        //send to club settings
        document.getElementById("inputListSendToClubActive").addEventListener("click", event => {
            ms.tmarket_list_send_to_club_active = event.target.checked;

            if (!event.target.checked) {
                document.getElementById('inputListSendToClubCommonPlayerCards').checked = false;
                ms.tmarket_list_send_to_club_common_player = false;

                document.getElementById('inputListSendToClubRarePlayerCards').checked = false;
                ms.tmarket_list_send_to_club_rare_player = false;

                document.getElementById('inputListSendToClubIfMinPrice').checked = false;
                ms.tmarket_list_send_to_club_if_min_price = false;

                //Özel fiyatı sıfırla
                ms.tmarket_list_buy_now_price = null;
                document.getElementById('inputListBuyNowPrice').value = null;
            }


            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListSendToClubCommonPlayerCards").addEventListener("click", event => {
            ms.tmarket_list_send_to_club_common_player = event.target.checked;

            if (event.target.checked) {
                document.getElementById('inputListSendToClubActive').checked = true;
                ms.tmarket_list_send_to_club_active = true;

                //Fiyat karşılaştırmayı kapat
                document.getElementById("inputListSendToClubIfMinPrice").checked = false;
                ms.tmarket_list_send_to_club_if_min_price = false;

                //Özel fiyatı sıfırla
                ms.tmarket_list_buy_now_price = null;
                document.getElementById('inputListBuyNowPrice').value = null;

            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListSendToClubRarePlayerCards").addEventListener("click", event => {
            ms.tmarket_list_send_to_club_rare_player = event.target.checked;

            if (event.target.checked) {
                document.getElementById('inputListSendToClubActive').checked = true;
                ms.tmarket_list_send_to_club_active = true;

                //Fiyat karşılaştırmayı kapat
                document.getElementById("inputListSendToClubIfMinPrice").checked = false;
                ms.tmarket_list_send_to_club_if_min_price = false;

                //Özel fiyatı sıfırla
                ms.tmarket_list_buy_now_price = null;
                document.getElementById('inputListBuyNowPrice').value = null;


            }
            mainJs.updateUserMenuSetting();
        });
        document.getElementById("inputListSendToClubIfMinPrice").addEventListener("click", event => {
            ms.tmarket_list_send_to_club_if_min_price = event.target.checked;

            if (event.target.checked) {
                document.getElementById('inputListSendToClubActive').checked = true;
                ms.tmarket_list_send_to_club_active = true;

                //Normal ve Nadirleri klübe göndermeyi iptal et
                document.getElementById('inputListSendToClubCommonPlayerCards').checked = false;
                ms.tmarket_list_send_to_club_common_player = false;
                document.getElementById('inputListSendToClubRarePlayerCards').checked = false;
                ms.tmarket_list_send_to_club_rare_player = false;

            }
            mainJs.updateUserMenuSetting();
        });


        //list settings
        // SEND TO TRANSFER LIST
        document.getElementById("input_add_to_tlist").addEventListener("change", event => {
            // ms.tmarket_listing_mode = event.target.checked ? 'add_to_tlist' : 'list_on_market';
            ms.tmarket_list_s_send_to_tlist = event.target.checked;

            //ms.tmarket_list_s_list_on_market = !event.target.checked;
            // document.getElementById('input_list_on_market').checked = !event.target.checked;
            // document.getElementById('trPackingPriceChange').hidden = event.target.checked;

            if (event.target.checked) {
                // ms.tmarket_send_to_club = !event.target.checked;
                // document.getElementById('inputPackSendToClubRarePlayerCards').checked = !event.target.checked;


                //En düşük fiyat ise klübe gönderi gizle
                // ms.pack_send_to_club_if_min = !event.target.checked;
                // document.getElementById('inputPackSendToClubIfMinPrice').checked = !event.target.checked;

                //En düşük fiyat ise hızlı satı da gizle
                // ms.pack_send_to_club_if_min = !event.target.checked;
                // document.getElementById('inputPackQSIfMinPrice').checked = !event.target.checked;

                // ms.pack_send_to_club_if_min = !event.target.checked;

                // document.getElementById('pack_send_to_club_settings').hidden = event.target.checked;

                // document.getElementById('trPackQuickSellIfMin').hidden = event.target.checked;
    
    
                //fiyat değişimini gizle göster
                // document.getElementById('trPackingPriceChange').hidden = event.target.checked;
            }


            mainJs.updateUserMenuSetting();
        });

        //LIST ON TRANSFER TRANSFER
        document.getElementById("input_list_on_market").addEventListener("change", event => {
            // ms.tmarket_listing_mode = event.target.checked ? 'list_on_market' : 'add_to_tlist';

            ms.tmarket_list_s_list_on_market = event.target.checked;
            

            //fiyat değişimini gizle göster
            document.getElementById('trPackingPriceChange').hidden = !event.target.checked;

            if (event.target.checked) {

                ms.tmarket_list_s_send_to_tlist = !event.target.checked;
                document.getElementById('input_add_to_tlist').checked = !event.target.checked;

                
                ms.tmarket_send_to_club = false;
                document.getElementById('inputPackSendToClubRarePlayerCards').checked = false;



                document.getElementById('pack_send_to_club_settings').hidden = false;


                //En düşük ise hızlı satı gizle göster
                // document.getElementById('trPackQuickSellIfMin').hidden = false;

                    // ms.quick_sell_quick_sell_if_min = !event.target.value;
                    // document.getElementById('inputPackQSIfMinPrice').checked = !event.target.value;
            }

            mainJs.updateUserMenuSetting();
        });

        document.getElementById("spanReListBuyNowPrice").addEventListener("keyup", event => {
            addLog(1256);
            if (!isNumeric(event.target.value)) {
                addLog(1258);
                // document.getElementById("inputReListQSMaxRating").value = null;
                ms.tmarket_list_buy_now_price = null;
                document.getElementById('spanReListBuyNowPrice').value = null;

            } else {
                addLog(1265);

                ms.tmarket_list_buy_now_price = event.target.value;

                document.getElementById('inputListSPriceChange').value = 0;
                ms.tmarket_list_s_price_change = 0;


                //quicksell
                if (document.getElementById('inputListQSActive').checked) {
                    mainJs.triggerButton('inputListQSActive');
                }


                //send to club
                if (document.getElementById('inputListSendToClubActive').checked) {
                    mainJs.triggerButton('inputListSendToClubActive');
                }


                // ms.tmarket_send_to_club_if_min = false;
                // document.getElementById('inputListSendClubCommonPlayers').checked = false;

                // ms.tmarket_list_qs_min_priced = false;
                // document.getElementById('inputListQSIfMinPrice').checked = false;

                // ms.tmarket_price_change = 0;
                // document.getElementById('inputListSPriceChange').value = 0;


                // ms.tmarket_price_change = null;
                mainJs.updateUserMenuSetting();
            }
        });
        document.getElementById("lblPriceChangeDown").addEventListener("click", event => {
            let val_ = document.getElementById('inputListSPriceChange').value;
            val_--;
            if (val_ < -3) { return; }

            document.getElementById('inputListSPriceChange').value = val_;
            ms.tmarket_list_s_price_change = val_;

            //Özel Fiyatı Nulla
            document.getElementById('inputListBuyNowPrice').value = null;
            ms.tmarket_list_buy_now_price = null;

            mainJs.updateUserMenuSetting();
        });
        document.getElementById("lblPriceChangeUp").addEventListener("click", event => {
            let val_ = document.getElementById('inputListSPriceChange').value;
            val_++;

            if (val_ > 3) { return; }

            document.getElementById('inputListSPriceChange').value = val_;
            ms.tmarket_list_s_price_change = val_;


            //Özel Fiyatı Nulla
            document.getElementById('inputListBuyNowPrice').value = null;
            ms.tmarket_list_buy_now_price = null;


            if (val_ > 0) {
                //en düşükse leri kapat
                document.getElementById('inputListSendToClubCommonPlayerCards').checked = false;
                ms.tmarket_list_send_to_club_if_min = false;

                document.getElementById('inputListQSIfMinPrice').checked = false;
                ms.tmarket_list_qs_if_min_price = false;

                document.getElementById('inputListBuyNowPrice').value = null;
                ms.tmarket_list_buy_now_price = null;
            }
            mainJs.updateUserMenuSetting();
        });