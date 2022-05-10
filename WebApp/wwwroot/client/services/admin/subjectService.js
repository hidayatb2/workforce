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



document.getElementById('ddlSemester').addEventListener('change', function (event) {
    document.getElementById("createSubjectDiv").style.visibility = "visible";
})

document.getElementById('postSubjectForm').addEventListener("submit", function (event) {
    event.preventDefault();
    let target = event.target;
    postSubjectFormData(target);
})

//add or Create
function postSubjectFormData(currentForm) {
    let forrmData = new FormData(currentForm);
    let semId = document.getElementById('ddlSemester').value;
    forrmData.append('semId', semId);
    apiHelper.post({
        url: currentForm.action,
        data: forrmData,
        success: (returnValue) => {
            if(returnValue > 0)
            tata.success('Success', 'Subject Added Successfully');
            else if(returnValue === -1)
            tata.warn('Warning', 'SubjectName Already Exists');
            else if(returnValue === -2)
            tata.warn('Warning', 'SubjectCode Already Exists');
        },
    });
}



document.deleteSubject=function (event) {
    event.preventDefault();
    if(confirm('Are you sure you want to Delete!')){
        let url = event.target.href;
        console.log(url);
        apiHelper.delete({
            url: url,
            accept: "text/html",
            success: (data) => {
                let partialSubjectDiv = document.getElementById("partialSubjectsData");
                partialSubjectDiv.innerHTML = "";
                partialSubjectDiv.innerHTML = data;
                tata.error('Alert', 'Subject Deleted Successfully');
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

$(document).on('change', '.ddlSem', function (event) {
    let semId = event.target.value;
    apiHelper.get({
        url: dataset.action + "/" + semId,
        accept: "text/html",
        success: (subjectHtml) => {
            let subjectDiv = document.getElementById('partialSubjectsData');
            subjectDiv.innerHTML = "";
            subjectDiv.innerHTML = subjectHtml;
        },

    });
})
