export const addCookie = (name, value, days) => {
  let expires = "";
  if (days) {
    let date = new Date();
    date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
    expires = "; expires=" + date.toGMTString();
  }
  document.cookie =
    name + "=" + encodeURIComponent(value) + expires + "; path=/";
};

export const getCookie = (name) => {
  let nameEqualTo = name + "=";
  let cookies = document.cookie.split(";");
  for (let i = 0; i < cookies.length; i++) {
    let cookie = cookies[i].trimStart();
    if (cookie.startsWith(nameEqualTo))
      return decodeURIComponent(
        cookie.substring(nameEqualTo.length, cookie.length)
      );
  }
  return null;
};

export const removeCookie = (name) => {
  addCookie(name, "", -1);
};
