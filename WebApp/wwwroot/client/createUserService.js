import apiHelpers from "./apiHelper.js";
let ddlVal=document.getElementById('role');
ddlVal.addEventListener('change', function (event) {
    document.getElementById('role1').style="display:block"
    let roleVal = event.target.value;
    if (roleVal == "Labour") {
        apiHelpers.get({
            url: "/admin/getallusersbyrole/" + roleVal,
            accept: "text/html",
            success: (users) => {
                let userListDiv = document.getElementById('mainD');
                userListDiv.innerHTML = users;
                userListDiv.style = "display:block"
    
            }
        });
    }

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