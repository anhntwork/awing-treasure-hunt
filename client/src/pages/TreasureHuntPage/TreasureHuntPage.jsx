import React, { useState } from "react";
import { Button, TextField, Grid2, Typography, Box, Card, CardContent } from "@mui/material";
import { apiRequest } from "../../services/api";
import { END_POINT } from "../../constants/ENDPOINT";
import { useAlert } from "../../contexts/AlertContext";

function TreasureHuntPage() {
    const [n, setN] = useState("");
    const [m, setM] = useState("");
    const [p, setP] = useState("");
    const [matrix, setMatrix] = useState([]);
    const [result, setResult] = useState(null);
    const showAlert = useAlert();
    const [errors, setErrors] = useState({ n: false, m: false, p: false, matrix: false });

    const handleMatrixChange = (row, col, value) => {
        const newMatrix = [...matrix];
        newMatrix[row] = newMatrix[row] || [];
        newMatrix[row][col] = parseInt(value) || 0;
        setMatrix(newMatrix);
    };

    const handleSubmit = async () => {
        const newErrors = {
            n: !n,
            m: !m,
            p: !p,
            matrix: matrix.length === 0 || matrix.some(row => row.length !== parseInt(m)),
        };
        setErrors(newErrors);
        if (Object.values(newErrors).some(error => error)) {
            showAlert.showAlert("Please fix the errors before submitting.", "error");
            return;
        }

        try {

            const headers = { "Content-Type": "application/json" };
            const body = { n: parseInt(n), m: parseInt(m), p: parseInt(p), matrix };

            const response = await apiRequest(END_POINT.CalculateFuel, "POST", headers, { body });

            if (response.isSuccess) {
                showAlert.showAlert(`Minimum Fuel: ${response.data}`, "success");
                setResult(response.data)
            } else {
                showAlert.showAlert(response.message || "Unknown error", "error");
            }
        } catch (error) {
            showAlert.showAlert("Failed to calculate fuel. Please try again.", "error");
        }
    };

    return (
        <Card> <CardContent>
            <Grid2 xs={12}>
                <Typography variant="h4">
                    Treasure Hunt
                </Typography>
            </Grid2>

        </CardContent>
            <CardContent>
                <Grid2 container spacing={2}>
                    <Grid2 xs={4}>
                        <TextField required label="Rows (n)" value={n} onChange={(e) => setN(e.target.value)} fullWidth
                            error={errors.n}
                            helperText={errors.n ? "This field is required" : ""} />
                    </Grid2>
                    <Grid2 xs={4}>
                        <TextField required label="Columns (m)" value={m} onChange={(e) => setM(e.target.value)} fullWidth
                            error={errors.m}
                            helperText={errors.m ? "This field is required" : ""} />
                    </Grid2>
                    <Grid2 xs={4}>
                        <TextField required label="Chests (p)" value={p} onChange={(e) => setP(e.target.value)} fullWidth
                            error={errors.p}
                            helperText={errors.p ? "This field is required" : ""} />
                    </Grid2>
                    <Grid2 xs={12}>
                        {Array.from({ length: n || 0 }).map((_, row) => (
                            <div key={row}>
                                {Array.from({ length: m || 0 }).map((_, col) => (
                                    <TextField required
                                        key={`${row}-${col}`}
                                        type="number"
                                        onChange={(e) => handleMatrixChange(row, col, e.target.value)}
                                        style={{ width: 60, margin: 5 }}
                                        error={errors.matrix}
                                        helperText={errors.matrix && row === 0 && col === 0 ? "Please complete the matrix" : ""}
                                    />
                                ))}
                            </div>
                        ))}
                    </Grid2>
                    <Grid2 xs={12}>
                        <Button variant="contained" onClick={handleSubmit}>
                            Calculate Fuel
                        </Button>
                    </Grid2>

                </Grid2>
            </CardContent>

            <CardContent>
                {result !== null && (
                    <Grid2 xs={12}>
                        <Typography variant="h1" gutterBottom>
                            {result}
                        </Typography>
                    </Grid2>
                )}
            </CardContent>
        </Card>
    );
}

export default TreasureHuntPage;
