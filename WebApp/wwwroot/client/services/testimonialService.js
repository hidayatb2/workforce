import apiHelper from "../helpers/apiHelper";
import apiUrls from "../helpers/apiUrls";
import { deleteObject } from "../helpers/serviceHelper";
import toastHelper from "../helpers/toastHelper";
import { deleteObject as delObj } from "./categoryService";

export const addTestimonial = async (testimonial, setTestimonials) => {
  await apiHelper.post({
    url: apiUrls.testimonial,
    data: testimonial,
    success: (data) => {
      toastHelper.success("Testimonial added successfully");
      getMyTestimonials(setTestimonials);
    },
  });
};

export const updateTestimonial = (testimonial) => {
  apiHelper.put({
    url: apiUrls.testimonial,
    data: testimonial,
    success: (data) => {
      toastHelper.success("Testimonial updated successfully");
    },
  });
};

export const deleteTestimonial = (id, data, setData) => {
  delObj(apiUrls.testimonial, id, data, setData);
};

export const getTestimonials = (setTestimonial) => {
  apiHelper.get({
    url: apiUrls.myTestimonial,
    success: setTestimonial,
  });
};

export const getMyTestimonials = (setTestimonial) => {
  apiHelper.get({
    url: apiUrls.myTestimonial,
    success: setTestimonial,
  });
};

export const getActiveTestimonials = (setTestimonials) => {
  apiHelper.get({
    url: apiUrls.activeTestimonial,
    success: setTestimonials,
  });
};

export const deleteMyTestimonial = (id, testimonials, setTestimonials) => {
  deleteObject(apiUrls.testimonial, id, testimonials, setTestimonials);
  // apiHelper.delete({
  //   url: apiUrls.testimonial+"/"+id,
  //   success: function (data) {
  //     toastHelper.success("Testimonial deleted successfully");
  //     getMyTestimonials(setTestimonial);
  //   },
  // });
};
