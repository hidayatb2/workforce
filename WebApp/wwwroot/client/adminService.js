import apiHelper from "./apiHelper.js";
document.getElementById('searchBox').addEventListener('keyup', function (event) {
     let searchString = event.target.value;
    apiHelper.get({
        url: "/admin/getuserby/" + searchString,
        accept: "text/html",
        success: (users) => {
            let userListDiv = document.getElementById('mainD');
            userListDiv.innerHTML = users;
            
            if (event.key == "Backspace") {
                if (document.getElementById('searchBox').value == "") {
                    userListDiv.innerHTML="";
                }
            }
    
        }
    });
})

document.getElementById('roleDiv').addEventListener('change', function (event) {
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