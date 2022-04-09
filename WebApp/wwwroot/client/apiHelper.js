////import toastHelper from "../services/tata-master/dist/tata.js";
const ajax = async (requestObject) => {
    let object = {
        method: requestObject.method,
        headers: {
            Accept: requestObject.accept || "application/json",
        },
    };

    if (object.method.toUpperCase() !== "GET") {
        object.body = requestObject.data;
        requestObject.contentType   || "multipart/form-data"; 
        //if (!requestObject.ignoreContentType)
        //    object.headers["Content-Type"] =
        //        requestObject.contentType   || "application/json";
    }
    try {
        let response = await fetch(requestObject.url, object);
        let data = await response.text();
        if (response.ok) {
            if (data && object.headers.Accept === "application/json")
                data = JSON.parse(data);
            if (requestObject.success)
                requestObject.success(data, response.headers, response.status);
            return data;
        } else {
            if (requestObject.error) requestObject.error(data, response.status);
            else handleError(data, response.status);
            return data;
        }
    } catch (ex) {
        console.error(ex);
    }
};

export const get = async (requestObject) => {
    requestObject.method = "GET";
    return await ajax(requestObject);
};

export const post = async (requestObject) => {
    requestObject.method = "POST";
    await  ajax(requestObject);
};


export const put = async (requestObject) => {
    requestObject.method = "PUT";
    await ajax(requestObject);
};

export const del = async (requestObject) => {
    requestObject.method = "DELETE";
    await ajax(requestObject);
};

const handleError = (data, status) => {
    if (status === 401) return toastHelper.error("You are not logged in");

    if (status === 403)
        return toastHelper.error("You do not have the required permission");
    if (data) {
        data = JSON.parse(data);
        toastHelper.error(data[0].message);
    }
};

export const postWithFile =  (requestObject) => {
    requestObject.method = "POST";
    requestObject.ignoreContentType = true;
    // requestObject.data = await getFormData(requestObject);
     ajax(requestObject);
};

export const putWithFile = async (requestObject) => {
    requestObject.method = "PUT";
    requestObject.ignoreContentType = true;
    // requestObject.data = await getFormData(requestObject);
     ajax(requestObject);
};

const getFormData = async (requestObject) => {
    let formData = new FormData();
    let keys = Object.keys(requestObject.data);
    for (let i = 0; i < keys.length; i++) {
        let key = keys[i];
        let obj = requestObject.data[key];
        if (!obj) continue;

        if (
            obj instanceof FileList ||
            (obj instanceof Array && obj.length && obj[0] instanceof File)
        ) {
            for (let j = 0; j < obj.length; j++) {
                formData.append(key, obj[j]);
            }
        } else if (obj instanceof Array || obj instanceof Object)
            formData.append(key, JSON.stringify(obj));
        else formData.append(key, obj);
    }
    return formData;
};

const apiHelper = { get, post, put, delete: del, postWithFile, putWithFile };

export default apiHelper;
