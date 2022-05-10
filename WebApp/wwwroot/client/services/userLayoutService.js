import apiHelper from "../helpers/apiHelper";
import apiUrls from "../helpers/apiUrls";

export const getMainNavs = (setMainNavs) => {
  apiHelper.get({
    url: apiUrls.mainNavList,
    success: function (data) {
      setMainNavs(data);
    },
  });
};

export const getCategories = (item, mainNavs, setMainNavs) => {
  if (!item.categories) {
    apiHelper.get({
      url: `${apiUrls.categoryList}/${item.id}`,
      success: function (data) {
        var newList = [...mainNavs];
        newList.splice(mainNavs.indexOf(item), 1, {
          ...item,
          categories: data,
        });
        setMainNavs(newList);
      },
    });
  }
};

export const getSearchSuggestions = (setData, searchText) => {
  apiHelper.get({
    url: apiUrls.searchSuggesstions + "/" + searchText,
    success: function (data) {
      setData(data);
    },
  });
};

export const getSearchedProducts = (setData, searchText) => {
  apiHelper.get({
    url: apiUrls.searchProduct + "/" + searchText,
    success: function (data) {
      setData(data);
    },
  });
};
