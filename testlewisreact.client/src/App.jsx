import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [exams, setExams] = useState();

    useEffect(() => {
        populateExamData();
    }, []);

    const contents = exams === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <p>exams.ExamName</p>

    return (
        <div>
            <h1 id="tableLabel">Exams</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateExamData() {
        console.log("Lewis was here");
        console.log("Lewis was here");
        const response = await fetch('https://localhost:7449/exam/name');
        const data = await response.json();
        console.log(data);
        console.log("Lewis was here");
        setExams(data);
    }
}

export default App;