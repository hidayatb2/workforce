import apiHelper from "./apiHelper.js";
document.getElementById('searchBox').addEventListener('keyup', function (event) {
     let searchString = event.target.value;
     let roleValue=ddlVal.value;
  if (event.key==="Enter") {
    apiHelper.get({
        url: "/admin/getuserby/" + searchString +"/"+ roleValue ,
        accept: "text/html",
        success: (users) => {
            let userListDiv = document.getElementById('mainD');
            userListDiv.innerHTML = users;
            
            
    
        }
    });
  }
  if (event.key === "Backspace") {
    
    apiHelper.get({
        url: "/admin/getuserby/" + searchString,
        accept: "text/html",
        success: (users) => {
            let userListDiv = document.getElementById('mainD');
            userListDiv.innerHTML = users;
            
            
    
        }
    });
 
}
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