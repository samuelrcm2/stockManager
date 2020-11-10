import { combineReducers } from "redux";

import alert from "./Alert/alertReducer";
import stockItems from "./StockItems/StockItemsReducer";
export default combineReducers({
  alert,
  stockItems,
});
