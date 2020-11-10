import React from "react";
import { Provider } from "react-redux";
import store from "./Store/store";
import Loader from "./Components/Generic/Loader/Loader";
import GenericAlert from "./Components/Generic/SnackbarAlert/Alert";
import Stock from "./Components/Stock/Stock";
import "./App.css";

import { createMuiTheme, ThemeProvider } from "@material-ui/core/styles";
import lime from "@material-ui/core/colors/lime";
import green from "@material-ui/core/colors/green";

const theme = createMuiTheme({
  palette: {
    primary: lime,
    secondary: green,
  },
});

const App = () => {
  return (
    <div className="Main">
      <Provider store={store}>
        <ThemeProvider theme={theme}>
          <Loader>
              <Stock />
            <GenericAlert />
          </Loader>
        </ThemeProvider>
      </Provider>
    </div>
  );
};

export default App;
