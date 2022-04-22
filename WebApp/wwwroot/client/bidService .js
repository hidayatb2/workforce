import apiHelper from "./apiHelper.js";



//document.addEventListener('submit', function (event) {
//    event.preventDefault();
//    let target = event.target;
//    let formId = target.id;
//    if (formId === 'postForm') postBidFormData(target);
//    else if (formId === 'putForm') putDeptFormData(target);
//    else if (formId === 'postCourseForm') postCourseFormData(target)
//    else if (formId === 'putCourseForm') putCourseFormData(target)

//})


function postBidFormData(currentForm) {
    apiHelper.post({
        url: currentForm.action,
        data: new FormData(currentForm),
        accept: "text/html",
        success: (data) => {
            let partailDiv = document.getElementById("partialBidData");
            partailDiv.innerHTML = "";
            partailDiv.innerHTML = data;
            swal("Bid Created Successfully", "", "success");
        },
    });
}

