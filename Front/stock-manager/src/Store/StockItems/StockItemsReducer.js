const INITIAL_STATE = {
  allStockItems: [],
  filteredStockItems: [],
};

const reducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case "FILTERED_STOCK_ITEMS_SETTED":
      return {
        ...state,
        filteredStockItems: action.payload,
      };
    case "ALL_STOCK_ITEMS_GETTED":
      return {
        ...state,
        allStockItems: action.payload,
        filteredStockItems: action.payload
      }
    default:
      return { ...state };
  }
};

export default reducer;
