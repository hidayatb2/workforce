import apiHelper from "../../helpers/apiHelper.js";

document.addEventListener('submit', function (event) {
    event.preventDefault();
    let target = event.target;
    let formId = target.id;
    if (formId === 'postForm') postDeptFormData(target);
    else if(formId ==='putForm') putDeptFormData(target);
    else if(formId === 'postCourseForm') postCourseFormData(target)
    else if (formId === 'putCourseForm') putCourseFormData(target)
    
})

 function postDeptFormData(currentForm)
 {
          apiHelper.post({
              url: currentForm.action,
              data: new FormData(currentForm),
              accept:"text/html",
              success: (data) => {
                  let partailDiv = document.getElementById("partialData");
                  partailDiv.innerHTML = "";
                  partailDiv.innerHTML = data;
                  tata.success('Success', 'Department Created Successfully');
              },
          });
 }


function putDeptFormData(currentForm){
        apiHelper.post({
            url: currentForm.action,
            data: new FormData(currentForm),
            success: (returnValue) => {
                if(returnValue > 0){
                    tata.info('Success', 'Department updated successfully')
                }
                else{
                    tata.error('Error', 'There is some issue please try after sometime')
                }
            },
        });
}


function postCourseFormData(currentForm){
        apiHelper.post({
            url: currentForm.action,
            data: new FormData(currentForm),
            accept: "text/html",
            success: (data) => {
                let partailDiv=  currentForm.parentElement.nextElementSibling;
                partailDiv.innerHTML = "";
                partailDiv.innerHTML = data;
                tata.success('Success', 'Course Added Successfully');
            },
        });
}

function putCourseFormData(currentForm) {
    apiHelper.post({
        url: currentForm.action,
        data: new FormData(currentForm),
        accept: "text/html",
        success: (data) => {
            let partailDiv = document.getElementById("partialSemestersData");
            partailDiv.innerHTML = "";
            partailDiv.innerHTML = data;
            tata.success('Success', 'Course Updated Successfully');
        },
    });
}
