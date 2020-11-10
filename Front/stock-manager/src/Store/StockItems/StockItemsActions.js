import api from "../../Services/Axios";
import { changeGenericAlert } from "../Alert/alertActions";

export const getAllStockItems = () => {
  return (dispatch) => {
    api.get("/StockItems").then((response) => {
      if (response) dispatch(addAllStockItemss(response.data));
    });
  };
};

export const addStockItem = (stockItemToEdit) => {
  return (dispatch) => {
    api.post("/StockItems/addStockItem", stockItemToEdit).then((response) => {
      if (response) {
        dispatch(getAllStockItems());
        dispatch(
          changeGenericAlert("Stock Item was added successfully", "success")
        );
      }
    });
  };
}

export const editStockItem = (stockItemToEdit) => {
  return (dispatch) => {
    api.post("/StockItems/updateStockItem", stockItemToEdit).then((response) => {
      if (response) {
        dispatch(getAllStockItems());
        dispatch(
          changeGenericAlert("Stock Item was edited successfully", "success")
        );
      }
    });
  };
}

export const deleteStockItem = (stockItemId) => {
  return (dispatch) => {
    api.post(`StockItems/deleteStockItem?stockItemId=${stockItemId}`).then((response) => {
      if (response) {
        dispatch(getAllStockItems());
        dispatch(
          changeGenericAlert("Stock Item was deleted successfully", "success")
        );
      }
    });
  };
}

//Actions
export const setFilteredStockItems = (filteredStockItems) => {
  return {
    type: "FILTERED_STOCK_ITEMS_SETTED",
    payload: filteredStockItems,
  };
};

export const addAllStockItemss = (allStockItems) => {
  return {
    type: "ALL_STOCK_ITEMS_GETTED",
    payload: allStockItems,
  };
};



