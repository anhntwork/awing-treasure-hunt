import React from "react";
import { AppBar, Toolbar, Typography, Tabs, Tab } from "@mui/material";
import { Link, useLocation } from "react-router-dom";
import HomeIcon from "@mui/icons-material/Home";
import HistoryIcon from "@mui/icons-material/History";

function Header() {
  const location = useLocation();
  const appName = import.meta.env.VITE_APP_NAME;

  return (
    <AppBar position="static" color="primary">
      <Toolbar>
        <Typography
          variant="h6"
          sx={{ flexGrow: 1, textDecoration: "none", color: "inherit" }}
          component={Link}
          to="/"
        >
          {appName}
        </Typography>
        <Tabs
          value={location.pathname}
          textColor="inherit"
        >
          <Tab
            label="Treasure Hunt"
            icon={<HomeIcon />}
            value="/"
            component={Link}
            to="/"
          />
          <Tab
            label="History"
            icon={<HistoryIcon />}
            value="/history"
            component={Link}
            to="/history"
          />
        </Tabs>
      </Toolbar>
    </AppBar>
  );
}

export default Header;
