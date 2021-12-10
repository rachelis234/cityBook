import logo from './logo.svg';
import './App.css';
import MyRouter from './components/MyRouter';

function App() {
  return (
    <div className="App">

      <h1>Welcome To Weather API!</h1>
      <MyRouter/>
      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header> */}
    </div>
  );
}

export default App;

