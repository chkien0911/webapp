$(document).ready(function () {
    
    //Set automcomplete dropdownlist
    $('select.combobox').select2();

    //Set format datetimepicker
    $('.datetimepicker').datetimepicker({
        //        pickTime: false 
    });
    $('.datepicker').datetimepicker({
        pickTime: false
    });
    $('.timepicker').datetimepicker({
        pickDate: false
    });
    //        setAutoHeight($('.grid-wrapper'));

    //alert(calcAutoHeight($('#content-wrapper'), 50));
});

$(document).ajaxError(function (e, xhr) {
    //    if (xhr.status == 403) {
    var response = $.parseJSON(xhr.responseText);
    alert(response.RedirectURL);
    window.location = response.RedirectURL;
    //    }
    //    else {
    //    }
});

function setAutoHeight(item) {
    var oldHeight = item.height();
    var newHeight = calcAutoHeight(item, 110);
    alert('old = ' + oldHeight);
    alert('new = ' + newHeight);
    item.height(newHeight);
}

function calcAutoHeight(item, bottomMargin) {
    var fromTop = item.offset().top + item.find('thead').height() + bottomMargin;
    return $(window).height() - fromTop;
}

function changeLanguage(currentLanguage, newLanguage) {
    try {
        if (currentLanguage == newLanguage) {
            return;
        }

        //change language
        $.ajax({
            url: '/Home/ChangeLanguage/' + encodeURIComponent(newLanguage),
            type: 'POST',
            success: function (data) {
                if (data.success) {  //show that id is valid
                    window.location = data.redirectUrl.replace("#", "");
                    //window.location.reload();
                }
                else { //show that id is not valid
                }
            }
        });
    } catch (e) {
    }
}

function showMessageBox(messageType, messageText, callback, isSubmit, formId) {
    switch (messageType) {
        case "YesNo":
            $('#yes-no-modal').find('p').text(messageText);
            $('#yes-no-modal').modal({ backdrop: 'static', keyboard: false })
                        .on('click', '#btnYes-yes-no-modal', function () {
                            if (typeof isSubmit !== 'undefined' && (isSubmit == true || isSubmit == 'submit')) {
                                if (typeof formId !== 'undefined' && formId != '') {
                                    $('#' + formId).trigger('submit'); // submit the form
                                }
                                else {
                                    $('#editForm').trigger('submit'); // submit the form
                                }
                            }
                            else {
                                callback();
                            }

                            $('#yes-no-modal').modal('hide');
                        });

            break;
        case "Ok":
        case "Close":
            $('#close-modal').find('p').text(messageText);
            $('#close-modal').modal({ backdrop: 'static', keyboard: false });
            break;
        case "OkClose":
            $('#ok-close-modal').find('p').text(messageText);
            $('#ok-close-modal').modal({ backdrop: 'static', keyboard: false })
                        .on('click', '#btnOk-ok-close-modal', function () {
                            //$form.trigger('submit'); // submit the form
                            callback();
                            $('#ok-close-modal').modal('hide');
                        });
            
            break;
        case "YesNoCancel":
            $('#yes-no-cancel-modal').find('p').text(messageText);
            $('#yes-no-cancel-modal').modal({ backdrop: 'static', keyboard: false })
                        .on('click', '#btnYes-yes-no-cancel-modal', function () {
                            //$form.trigger('submit'); // submit the form
                            callback();
                            $('#yes-no-modal').modal('hide');
                        });
            
            break;
        default:
            break;

    }
};
