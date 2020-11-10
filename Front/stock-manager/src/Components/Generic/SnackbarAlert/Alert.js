import React, { useEffect } from "react";
import { bindActionCreators } from "redux";
import Snackbar from "@material-ui/core/Snackbar";
import MuiAlert from "@material-ui/lab/Alert";
import { makeStyles } from "@material-ui/core/styles";
import { connect } from "react-redux";
import api from "../../../Services/Axios";
import * as alertActions from "../../../Store/Alert/alertActions";

const useStyles = makeStyles((theme) => ({
  root: {
    "& > * + *": {
      marginTop: theme.spacing(2),
    },
    zIndex: 99999999999,
  },
}));

function AlertFormat(props) {
  return <MuiAlert elevation={6} variant="filled" {...props} />;
}

const Alert = (props) => {
  const classes = useStyles();
  const {
    type,
    message,
    active,
    changeGenericAlert,
    closeGenericAlert,
  } = props;
  useEffect(() => {
    api.interceptors.response.use(
      (response) => {
        return response;
      },
      (error) => {
        changeGenericAlert("An error has occurred", "error");
        return Promise.reject(error);
      }
    );
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const handleClose = (_, reason) => {
    if (reason === "clickaway") {
      return;
    }

    closeGenericAlert();
  };
  return (
    <div className={classes.root}>
      <Snackbar open={active} autoHideDuration={4000} onClose={handleClose}>
        <AlertFormat onClose={handleClose} severity={type}>
          {message}
        </AlertFormat>
      </Snackbar>
    </div>
  );
};

const mapStateToProps = (state) => ({
  active: state.alert.active,
  message: state.alert.message,
  type: state.alert.type,
});

const mapDispatchToProps = (dispatch) => {
  return bindActionCreators(alertActions, dispatch);
};

export default connect(mapStateToProps, mapDispatchToProps)(Alert);
