import apiUrls from "../helpers/apiUrls";
import { getUrlWithQueryString } from "../helpers/generalHelper";
import { getList } from "../helpers/serviceHelper";

export const getGroups = (setGroups) => {
  getList(
    getUrlWithQueryString(apiUrls.stockGroupsWithDetails, {
      orderBy: "sortOrder",
      sortOrder: "asc",
      pageNo: 0,
    }),
    setGroups
  );
};
