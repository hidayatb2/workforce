import apiHelper from "./apiHelper.js";
document.getElementById('searchBox').addEventListener('keyup', function (event) {
     let searchString = event.target.value;
     let roleValue=ddlVal.value;
     let userListDiv = document.getElementById('mainD');
  if (event.key==="Enter") {
    apiHelper.get({
        url: "/admin/getuserby/" + searchString +"/"+ roleValue ,
        accept: "text/html",
        success: (users) => {
            userListDiv.innerHTML="";
            userListDiv.innerHTML = users;
        }
    });
    if (searchString === "") {
        userListDiv.innerHTML="";
    }
  }
//   if (event.key === "Backspace") {
    
//     apiHelper.get({
//         url: "/admin/getuserby/" + searchString,
//         accept: "text/html",
//         success: (users) => {
//             let userListDiv = document.getElementById('mainD');
//             userListDiv.innerHTML = users;
            
            
    
//         }
//     });
 
// }
})


let ddlVal=document.getElementById('roleDiv');
ddlVal.addEventListener('change', function (event) {
    let roleVal = event.target.value;
    apiHelper.get({
        url: "/admin/getallusersbyrole/" + roleVal,
        accept: "text/html",
        success: (users) => {
            let userListDiv = document.getElementById('mainD');
            userListDiv.innerHTML = users;
            userListDiv.style = "display:block"

        }
    });
})


// apiHelper.put({
//     url: "",
//     data: formData,
//     accept: "text/html",
//     success: (data) => {
//         let partialSubjectDiv = document.getElementById("partialQuestiosData");
//         partialSubjectDiv.innerHTML = "";
//         partialSubjectDiv.innerHTML = data;
//         tata.info('Updated', 'Question Updated Successfully');
//     }
// })


let ddlRole=document.getElementById('role');
ddlRole.addEventListener('change', function (event) {
    document.getElementById('role1').style="display:block";
    // apiHelper.get({
    //     url: "/admin/getallusersbyrole/" + roleVal,
    //     accept: "text/html",
    //     success: (users) => {
    //         let userListDiv = document.getElementById('mainD');
    //         userListDiv.innerHTML = users;
    //         userListDiv.style = "display:block"

    //     }
    // });
})






$(document).on('change','.chkStatus',function(e){
   let id= e.target.value;
    alert('hi');
})


