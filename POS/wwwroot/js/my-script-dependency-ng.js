function getDependencyModule() {
    setTimeout(() => {
        window.console.log('Dependency added successfully');
    }, 1500);
}

export { getDependencyModule }