import apiHelper from "../../helpers/apiHelper.js";

document.addEventListener('submit', function (event) {
    event.preventDefault();
    let target = event.target;
    let formId = target.id;
    if (formId === 'postForm') postSliderFormData(target);
    //else if (formId === 'putForm') putDeptFormData(target);
    //else if (formId === 'postCourseForm') postCourseFormData(target)
    //else if (formId === 'putCourseForm') putCourseFormData(target)

})



function postSliderFormData(currentForm) {
    let d = new FormData(currentForm);
    let ee = d.get("caption");
    let fil = d.get("file");

    apiHelper.postWithFile({
        url: currentForm.action,
        data: new FormData(currentForm),
        accept: "text/html",
        success: (data) => {
            let partailDiv = document.getElementById("partialData");
            partailDiv.innerHTML = "";
            partailDiv.innerHTML = data;
            tata.success('Success', 'Slider Created Successfully');
        },
    });
}





