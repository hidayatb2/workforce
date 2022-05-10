import apiHelper from "../helpers/apiHelper";
import toastHelper from "./toastHelper";

export const save = (apiUrl, model, setModel, setList, newModel) => {
  apiHelper.post({
    url: apiUrl,
    data: model,
    success: () => {
      getList(apiUrl, setList);
      setModel(newModel);
      toastHelper.success("Saved Successfully");
    },
  });
};

export const getList = (api, setList) => {
  apiHelper.get({
    url: api,
    success: function (data, headers) {
      setList(data);
    },
  });
};

export const update = (api, model) => {
  apiHelper.put({
    url: api,
    data: model,
    success: function () {
      toastHelper.success("Updated Successfully");
    },
  });
};

export const deleteObject = (api, id, list, setList) => {
  if (window.confirm("Are you sure you want to delete this?")) {
    apiHelper.delete({
      url: api + "/" + id,
      success: function () {
        setList(list.filter((x) => x.id !== id));
        toastHelper.success("Deleted Successfully");
      },
    });
  }
};
