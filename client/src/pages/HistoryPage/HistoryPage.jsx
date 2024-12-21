import React, { useEffect, useState } from "react";
import { Table, TableBody, TableCell, TableHead, TableRow, Typography, Container } from "@mui/material";
import { END_POINT } from "../../constants/ENDPOINT";
import { apiRequest } from "../../services/api";

function HistoryPage() {
  const [history, setHistory] = useState([]);

  useEffect(() => {
    const fetchHistory = async () => {
      try {
        const response = await apiRequest(END_POINT.History, "GET");
        setHistory(response.data);
      } catch (error) {
        console.error("Error fetching history:", error);
      }
    };

    fetchHistory();
  }, []);

  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        Calculation History
      </Typography>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>ID</TableCell>
            <TableCell>Matrix</TableCell>
            <TableCell>Result</TableCell>
            <TableCell>Created At</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {history.map((row) => (
            <TableRow key={row.id}>
              <TableCell>{row.id}</TableCell>
              <TableCell>
                <pre>{row.matrix}</pre>
              </TableCell>
              <TableCell>{row.result}</TableCell>
              <TableCell>{new Date(row.createdAt).toLocaleString()}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Container>
  );
}

export default HistoryPage;
