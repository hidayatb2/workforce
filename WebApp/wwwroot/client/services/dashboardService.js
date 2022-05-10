import apiHelper from "../helpers/apiHelper";
import apiUrls from "../helpers/apiUrls";

export const getYears = () => {
  let startYear = 2020;
  let currentYear = new Date().getFullYear();
  let years = [];
  while (startYear <= currentYear) {
    years.push({
      text: startYear,
    });
    startYear++;
  }
  return years;
};

export const getPeriod = () => [
  { text: "As Of Now", value: "0" },
  { text: "Today", value: "1" },
  { text: "This Week", value: "2" },
  { text: "Last Week", value: "3" },
  { text: "This Month", value: "4" },
  { text: "Last Month", value: "5" },
  { text: "This Year", value: "6" },
  { text: "Last Year", value: "7" },
  { text: "Custom", value: "8" },
];

export const getMonthlySales = (setMonthlySales, year = null) => {
  apiHelper.get({
    url: apiUrls.monthlySales + "/" + year,
    success: setMonthlySales,
  });
};

const getDateFilterQueryString = (dateFilter, url) => {
  if (!dateFilter) return url;
  if (dateFilter.period !== "8") {
    url += "?period=" + dateFilter.period;
  } else {
    url +=
      "?period=" +
      dateFilter.period +
      "&startDate=" +
      dateFilter.startDate +
      "&endDate=" +
      dateFilter.endDate;
  }
  return url;
};

export const getSalesWidget = (setSalesWidget, dateFilter) => {
  let url = getDateFilterQueryString(dateFilter, apiUrls.salesWidget);
  apiHelper.get({
    url,
    success: setSalesWidget,
  });
};

export const getProductWidget = (setProductWidget, dateFilter) => {
  let url = getDateFilterQueryString(dateFilter, apiUrls.productWidget);
  apiHelper.get({
    url,
    success: setProductWidget,
  });
};

export const getOrderWidget = (setOrderWidget, dateFilter) => {
  let url = getDateFilterQueryString(dateFilter, apiUrls.salesWidget);
  apiHelper.get({
    url,
    success: setOrderWidget,
  });
};

export const getQuantityTrackerList = (setQuantityTracker, count) => {
  apiHelper.get({
    url: apiUrls.quantityTracker + "?count=" + count,
    success: setQuantityTracker,
  });
};
