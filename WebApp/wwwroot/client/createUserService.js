import apiHelpers from "./apiHelper.js";

let ddlVal=document.getElementById('role');
let ddl = document.getElementById('role1');

ddlVal.addEventListener('change', function (event) {
    let roleVal = event.target.value;
    if (roleVal != "5" && roleVal != "4") {
        ddl.style="display:none";
        return;
    }
       else{
        apiHelpers.get({
            url: "/admin/managers/" + roleVal,
            success: (roles) => {
               if (roles != null) {
               ddl.style="display:block";
               ddl.innerText="";
               let slct=new Option("Select","");
               ddl.appendChild(slct);
               roles.map(role=>{
                    let options =new Option(role.userName,role.id);
                    ddl.appendChild(options);
                })
               }
    
            }
        });
       }
})