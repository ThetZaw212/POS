import { getDependencyModule } from './my-script-dependency-ng.js';

function getHelloWorldAlert() {
    window.alert('Hello World From Module');
    getDependencyModule();
}

function getHelloWorldConsole() {
    console.log('Hello World From Console');
}

export { getHelloWorldAlert, getHelloWorldConsole,getDependencyModule }