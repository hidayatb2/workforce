import apiHelper from "../../helpers/apiHelper.js";

let id = document.getElementById('ddlDepartment').value;
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


document.getElementById('ddlCourse').addEventListener('change', function (event) {
    let id = event.target.value;
    apiHelper.get({
        url: "/Subject/GetSemesters/" + id,
        success: (semesters) => {
            let ddlSemester = document.getElementById('ddlSemester');
            ddlSemester.innerHTML = "";
            ddlSemester.append(new Option("Select Semester", ""));
            semesters.map(function (semesters) {
                ddlSemester.append(new Option(semesters.sem, semesters.id));
            })
        },
    });
})

document.getElementById('ddlSemester').addEventListener('change', function (event) {
    let id = event.target.value;
    apiHelper.get({
        url: "/Subject/GetSubjects/" + id,
        success: (subjects) => {
            let ddlSubject = document.getElementById('ddlSubject');
            ddlSubject.innerHTML = "";
            ddlSubject.append(new Option("Select Subject", ""));
            subjects.map(function (subjects) {
                ddlSubject.append(new Option(subjects.subjectName, subjects.id));
            })
        },
    });
})


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