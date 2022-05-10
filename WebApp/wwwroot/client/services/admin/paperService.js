import apiHelper from "../../helpers/apiHelper.js";

//Get Id Of Current Event
document.addEventListener('submit', function (event) {
    let target = event.target;
    let formId = target.id;
    if (formId === 'paperPostForm') paperPostForm(target);
})

//Creatation Of Paper 

function paperPostForm(currentForm) {
    event.preventDefault();
    if(document.getElementById('ddlSubject').value == ""){
        tata.warn('Warn','Please Select Subject First');
        return false;
    } 
    apiHelper.post({
        url: currentForm.action,
        data: new FormData(currentForm),
        success: (returnValue) => {
            if(returnValue > 0){
                tata.success('Success', 'Paper Created Successfully');
            }
            else if(returnValue === -1){
                tata.warn('Warning','Exam date cannot be less then current date')
            }
            else
            {
                tata.warn('Error','Try Again Later');
            }
        },
    });
}
// Get Papers By Subject Id
document.getElementById('ddlSubject').addEventListener('change', function (event) {
    let id = event.target.value;
    apiHelper.get({
        url: "/paper/getpaper/" + id,
        accept: "text/html",
        success: (papers) => {
            let paperListDiv = document.getElementById('paperListPartial');
            paperListDiv.innerHTML = "";
            paperListDiv.innerHTML = papers;
            paperListDiv.style.display = "block";
        }
    });
})
//Delete Paper Template
document.deletePaper=function (event) {
    event.preventDefault();
    if(confirm('Are you sure you want to Delete!')){
        let url = event.target.href;
        apiHelper.delete({
            url: url,
            accept: "text/html",
            success: (data) => {
                let paperListContainer = document.getElementById("paperListContainer");
                paperListContainer.innerHTML = "";
                paperListContainer.innerHTML = data;
                tata.error('Alert', 'Paper Deleted Successfully');
            }
        })
    }
 }

document.UpdateSubject=function (event){
    event.preventDefault();
    let currentForm = event.target;
    let forrmData = new FormData(currentForm);
    let url=  currentForm.action
  if(confirm('Are you sure you want to update!')){
    apiHelper.delete({
        url: url,
        data:forrmData,
        accept: "text/html",
        success: (data) => {
            let partialSubjectDiv = document.getElementById("partialSubjectsData");
            partialSubjectDiv.innerHTML = "";
            partialSubjectDiv.innerHTML = data;
            tata.info('Updated', 'Subject Updated Successfully');
        }
    })
  }
}

//Get Selected Questions From Question Bank
document.getElementById('btnAddQuestion').addEventListener('click', function (event) {
        let chkBoxes = document.querySelectorAll("input[type='checkBox']:checked");
        let paperQuestions = [];
        let myForm=new FormData();
        for (let i=0; i < chkBoxes.length; i++) {
            paperQuestions.push({
                "paperId":this.dataset.id,
                "questionId":chkBoxes[i].dataset.value,
                "marks":chkBoxes[i].parentElement.nextElementSibling.firstChild.value
            });
        }
        $.ajax({
            url:"/paper/addquestion",
            type:"post",
            contentType:"application/json",
            data:JSON.stringify(paperQuestions),
            success:(returnValue)=>{
                        if(returnValue > 0 ){
                            tata.info('Added','Questions Added Successfully');
                        }else{
                            tata.error('Failed','Try Again Later');
                        }
                    }
        })
        // apiHelper.post({
        //     url:"/paper/addquestion",
        //     data:JSON.stringify(paperQuestions),
        //     contentType:"application/json",
        //     Accept:"application/json",
        //     success:(returnValue)=>{
        //         // if(returnValue > 0 ){
        //         //     tata.info('Added','Questions Added Successfully');
        //         // }else{
        //         //     tata.error('Failed','Try Again Later');
        //         // }
        //     }
        // })
})