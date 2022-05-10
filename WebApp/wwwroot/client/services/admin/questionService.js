import apiHelper from "../../helpers/apiHelper.js";
//Function For Get All Questions By SubId
function getQuestions(id) {
    apiHelper.get({
        url: "/question/getquestionbysub/" + id,
        accept: "text/html",
        success: (questions) => {
            let questionListDiv = document.getElementById('partialQuestiosData');
            questionListDiv.innerHTML = "";
            questionListDiv.innerHTML = questions;
        }
    });
}


document.getElementById('ddlDepartment').addEventListener('change', function (event) {
    let id = event.target.value;
    apiHelper.get({
        url: "/Subject/GetCourses/"+id,
        success: (courses) => {
            let ddlCourse = document.getElementById('ddlCourse');
            ddlCourse.innerHTML = "";
            ddlCourse.append(new Option("Select Course", ""));

            courses.map(function (course) {
                ddlCourse.append(new Option(course.courseName, course.id));
            })
        },
    });
})


document.getElementById('ddlCourse').addEventListener('change', function (event) {
    let id = event.target.value;
    apiHelper.get({
        url: "/Subject/GetSemesters/" + id,
        success: (semesters) => {
            
           // document.getElementById('partialSubjectsData').innerHTML="";
            let ddlSemester = document.getElementById('ddlSemester');
            ddlSemester.innerHTML = "";
            ddlSemester.append(new Option("Select Semester", ""));

            semesters.map(function (semester) {
                ddlSemester.append(new Option(semester.sem, semester.id));
            })
        },
        
    });
   
})





//question by subject Id
document.getElementById('ddlSubject').addEventListener('change', function (event) {
    let id = event.target.value;
    getQuestions(id);
})




document.getElementById('ddlSemester').addEventListener('change', function (event) {
    let id = event.target.value;
    apiHelper.get({
        url: "/Subject/GetSubjects/" + id,
        success: (subjects) => {
            let ddlSubject = document.getElementById('ddlSubject');
            ddlSubject.innerHTML = "";
            ddlSubject.append(new Option("Select Subject", ""));
            subjects.map(function (subject) {
                ddlSubject.append(new Option(subject.subjectName, subject.id));
            })
        },

    });
})

document.getElementById('postQuestionForm').addEventListener("submit", function (event) {
    event.preventDefault();
    let target = event.target;
    postQuestionFormData(target);
})




function postQuestionFormData(currentForm) {
    let formData = new FormData(currentForm);
    let subId = document.getElementById('ddlSubject').value;
    if (subId === "") {
        tata.error('Error', 'Please Select Subject');
        return false;
    }
    formData.append('subjectId', subId);
    apiHelper.post({
        url: currentForm.action,
        data: formData,
        accept: "text/html",
        success: (questions) => {
            getQuestions(subId);
            tata.success("Success","Question added successfully")
        },
    });
}

document.updateQuestion = function (event) {
    event.preventDefault();
    let currentForm = event.target;
    let formData = new FormData(currentForm);
    let url = currentForm.action
    if (confirm('Are you sure you want to update!')) {
        apiHelper.put({
            url: url,
            data: formData,
            accept: "text/html",
            success: (data) => {
                let partialSubjectDiv = document.getElementById("partialQuestiosData");
                partialSubjectDiv.innerHTML = "";
                partialSubjectDiv.innerHTML = data;
                tata.info('Updated', 'Question Updated Successfully');
            }
        })
    }
}

