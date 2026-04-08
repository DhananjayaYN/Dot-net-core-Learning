import React, {useState, useEffect, use} from "react";

const Dashboard = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        fetch(' http://localhost:5129/weatherforecast')
            .then(response => response.json())
            .then(data => setData(data))
            .catch(error => setError(error));
    }, []);

    return(
        <div className="dashboard">
            <h2>Weather Dashboard</h2>
            <div className="weather-grid">
                {data.map((item, index) => (
                    <div key={index} className="weather-card">
                        <h3>{item.date}</h3>
                        <p>Temperature: {item.temperatureC}°C</p>
                        <p>Summary: {item.summary}</p>
                    </div>
                ))}
            </div>
        </div>

    );
};

export default Dashboard;