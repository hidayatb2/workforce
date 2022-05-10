import apiHelper from "../../helpers/apiHelper.js";




$(document).on('submit','.postNotification',function(event){
    event.preventDefault();
    apiHelper.post({
        url: event.target.action,
        data:new FormData(event.target),
        ignoreContentType:true,
        accept: "text/html",
        success: (notifictionHtml) => {
            let notificationDiv = document.getElementById("notficationListDiv");
            notificationDiv.innerHTML = "";
            notificationDiv.innerHTML = notifictionHtml;
            tata.info('Add', 'Notification Added Successfully');
        }
    })

})
