import apiHelper from "../../helpers/apiHelper.js";



$(document).on('change', '.ddlSem', function (event) {
   
    let semId = event.target.value;
    let subjectDiv = document.getElementById('subjectsBySemDiv');
    apiHelper.get({
        url: "/Student/PapersBySem/" + semId,
        accept: "text/html",
        success: (subjectHtml) => {
            //let subjectDiv = document.getElementById('partialSubjectsData');
            subjectDiv.innerHTML = "";
            subjectDiv.innerHTML = subjectHtml;
        },

    });
})
