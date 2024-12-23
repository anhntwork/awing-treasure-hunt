import React, { createContext, useContext, useState } from "react";
import { Snackbar, Alert } from "@mui/material";

const AlertContext = createContext();

export const AlertProvider = ({ children }) => {
  const [alert, setAlert] = useState({ open: false, message: "", severity: "info" });

  const showAlert = (message, severity = "info") => {
    setAlert({ open: true, message, severity });
  };

  const closeAlert = () => {
    setAlert({ ...alert, open: false });
  };

  return (
    <AlertContext.Provider value={{ showAlert }}>
      {children}
      <Snackbar
        open={alert.open}
        autoHideDuration={3000}
        onClose={closeAlert}
        anchorOrigin={{ vertical: "top", horizontal: "center" }}
      >
        <Alert onClose={closeAlert} severity={alert.severity} sx={{ width: "100%" }}>
          {alert.message}
        </Alert>
      </Snackbar>
    </AlertContext.Provider>
  );
};

export const useAlert = () => {
  return useContext(AlertContext);
};
