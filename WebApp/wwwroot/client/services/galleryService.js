import apiHelper from "../helpers/apiHelper";
import apiUrls from "../helpers/apiUrls";
import { getList } from "../helpers/serviceHelper";
import toastHelper from "../helpers/toastHelper";

export const saveGalleryItem = (gallery, setGallery) => {
  if (gallery.file == null) {
    return toastHelper.warn("Select File");
  }

  apiHelper.postWithFile({
    url: apiUrls.gallery,
    data: gallery,
    success: () => {
      toastHelper.success("File Uploaded Successfully");
      setGallery({ title: "", description: "", file: null });
    },
  });
};

export const getGalleryItems = (setGalleries) => {
  apiHelper.get({
    url: apiUrls.gallery,
    success: function (data) {
      setGalleries(data);
    },
  });
};


export const getGalleryItemById = (setGallery, id) => {
  apiHelper.get({
    url: apiUrls.gallery + "/" + id,
    success: function (data) {
      setGallery(data);
    },
  });
};

export const getTopGalleryItems = (setGalleries) => {
  apiHelper.get({
    url: apiUrls.topGalleryItems,
    success: function (data) {
      setGalleries(data);
    },
  });
};

export const updateGalleryItem = (gallery, setGallery) => {
  apiHelper.putWithFile({
    url: apiUrls.gallery,
    data: gallery,
    success: function (data) {
      toastHelper.success("Gallery updated successfully");
      setGallery(data);
    },
  });
};


export const deleteGalleryItem = (id, setGalleries) => {
  if (window.confirm("Are you sure you want to delete this?")) {
    apiHelper.delete({
      url: apiUrls.gallery + "/" + id,
      success: function () {
        getList(apiUrls.gallery, setGalleries);
        toastHelper.success("Deleted Successfully");
      },
    });
  }
};
