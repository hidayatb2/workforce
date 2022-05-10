import apiHelper from "../../helpers/apiHelper.js";
var cnt = 0;
var slideIndex = 1;
showDivs(slideIndex);
showDivs(slideIndex += 1);

window.plusDivs=function (event, n) {
    saveAnswer(event);
    showDivs(slideIndex += n);
}
function showDivs(n) {
    //history.back();
    var i;
    var x = document.getElementsByClassName("mySlides");
    if (n > x.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = x.length }
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    x[slideIndex - 1].style.display = "block";
}
function saveAnswer(event) {
   
    let btn = event.target;
    let questionId = btn.dataset.questionid;
    let paperId = btn.dataset.paperid;
    //let res = document.getElementsByName(questionId);
    let answer = document.querySelectorAll('input[type="radio"]:checked')[0].value;
    let formData = new FormData();
    formData.append("questionId", questionId);
    formData.append("paperId", paperId);
    formData.append("answer", answer);
    formData.append("count", ++cnt);
    apiHelper.post({
        url: "/Student/SubmitQuestion",
        data: formData,
        success: (nextQuestion) => {
           let paperQuestionDiv = document.getElementById('paperQuestionDiv');
           paperQuestionDiv.innerHTML="";
           paperQuestionDiv.innerHTML=nextQuestion;
        },
    });

}
