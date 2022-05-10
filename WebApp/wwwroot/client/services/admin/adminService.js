import apiHelper from "../../helpers/apiHelper.js";

let createSubjectDiv = document.getElementById('createSubjectDiv');

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
        success: (courses) => {
            
            document.getElementById('partialSubjectsData').innerHTML="";
            let ddlSemester = document.getElementById('ddlSemester');
            ddlSemester.innerHTML = "";
            ddlSemester.append(new Option("Select Semester", ""));

            courses.map(function (course) {
                ddlSemester.append(new Option(course.sem, course.id));
            })
        },
        
    });
   
})


$(document).on('change', '.ddlSem', function (event) {
    let semId = event.target.value;
    apiHelper.get({
        url: "/Subject/GetSubjectsBySem/" + semId,
        accept: "text/html",
        success: (subjectHtml) => {
            let subjectDiv = document.getElementById('partialSubjectsData');
            subjectDiv.innerHTML = "";
            subjectDiv.innerHTML = subjectHtml;
        },

    });
})
