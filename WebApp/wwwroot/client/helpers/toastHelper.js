import { toast } from "react-toastify";

const toastOptions = {
  position: "top-center",
  autoClose: 3000,
  // autoClose: false,
  hideProgressBar: false,
  closeOnClick: true,
  pauseOnHover: true,
  draggable: true,
  theme: "light",
};

const error = (message) => {
  toast.error(message, toastOptions);
};

const success = (message) => {
  toast.success(message, toastOptions);
};

const warn = (message) => {
  toast.warn(message, toastOptions);
};

const info = (message) => {
  toast.info(message, toastOptions);
};

const toastHelper = { error, success, warn, info };

export default toastHelper;
