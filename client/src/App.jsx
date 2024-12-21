import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import TreasureHuntPage from './pages/TreasureHuntPage/TreasureHuntPage';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<TreasureHuntPage />} />
      </Routes>
    </Router>
  );
}

export default App;
