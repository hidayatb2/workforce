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

