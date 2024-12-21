import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import TreasureHuntPage from './pages/TreasureHuntPage/TreasureHuntPage';
import HistoryPage from './pages/HistoryPage/HistoryPage';
import Header from './components/common/Header';
import Footer from './components/common/Footer';

function App() {
  return (
    <Router>
      <div style={{ flex: 1 }}>
        <Header />
        <Routes>
          <Route path="/" element={<TreasureHuntPage />} />
          <Route path="/history" element={<HistoryPage />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;
