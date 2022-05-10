import apiHelper from "../helpers/apiHelper";
import apiUrls from "../helpers/apiUrls";
import toastHelper from "../helpers/toastHelper";
import { ADMIN_ROUTES } from "../routes/routes";

//Stock section starts

export const getRoles = () => [
  {
    text: "Customer",
  },
  {
    text: "Admin",
  },
  {
    text: "Manager",
  },
];

export const getStatus = () => [
  {
    text: "Active",
  },
  {
    text: "InActive",
  },
];

export const getEmployeeList = (setList) => {
  apiHelper.get({
    url: apiUrls.employees,
    success: function (data) {
      setList(data);
    },
  });
};

export const saveEmployee = (model, history) => {
  apiHelper.post({
    url: apiUrls.employees,
    data: model,
    success: (data) => {
      toastHelper.success("Employee Created Successfully");
      history.push(ADMIN_ROUTES.editEmployee.path.replace(":id", data.id));
    },
  });
};

export const updateEmployee = (model) => {
  apiHelper.put({
    url: apiUrls.employees,
    data: model,
    success: () => {
      toastHelper.success("Updated Successfully");
    },
  });
};

export const getEmployee = (id, setEmployee) => {
  apiHelper.get({
    url: apiUrls.employees + "/" + id,
    success: (data) => {
      setEmployee(data);
    },
  });
};

// export const deleteEmployee = (id, list, setList) => {
//   deleteObject(apiUrls.employees, id, list, setList);
// };
