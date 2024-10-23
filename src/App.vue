<!-- src/App.vue -->
<template>
  <div id="app" :class="{'dark-mode': darkMode, 'app-background': true}">
    <header class="header">
      <img :src="darkMode ? require('./assets/logo-dark.svg') : require('./assets/logo.svg')" alt="Logo" class="header-logo" />
      <button @click="toggleDarkMode" class="header-dark-mode-button">
        {{ darkMode ? "Desativar Modo Dark" : "Ativar Modo Dark" }}
      </button>
    </header>
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      darkMode: JSON.parse(localStorage.getItem('darkMode')) || false,
    };
  },
  methods: {
    toggleDarkMode() {
      this.darkMode = !this.darkMode;
      localStorage.setItem('darkMode', JSON.stringify(this.darkMode));
    },
  },
};
</script>


  
<style scoped>
.app-background {
  min-height: 00vh;
  display: flex;
  justify-content: top;
  align-items: flex-start;
  flex-direction: column;
  padding: 20px;
  color: var(--title-color);
  background-color: var(--background-color); /* Use a variável para a cor de fundo */
  transition: background-color 0.3s;
}

/* Estilos para o modo escuro */
.dark-mode .app-background {
  background-image: none;
  background-color: var(--background-color);
  transition: background-color 0.3s;
}

.header {
  transition: background-color 0.3s;
  background-color: var(--background-color);
  padding: 10px;
  display: flex;
  justify-content: space-evenly;
  align-items: center;
  width: 100%;
}

.header-logo {
  max-width: 150px;
  height: auto;
}

.header-title {
  margin: 0;
  font-size: 1.5rem;
  color: var(--title-color);
}

.header-dark-mode-button {
  transition: background-color 0.3s;
  padding: 5px;
  background-color: var(--button-color);
  border: 1px solid var(--border-color);
  border-radius: 4px;
  font-size: 1rem;
  cursor: pointer;
  color: var(--text-color);
}

.header-dark-mode-button:hover {
  background-color: var(--button-hover-color);
}

.back-button {
  padding: 5px;
  background-color: var(--button-color);
  border: 1px solid var(--border-color);
  border-radius: 4px;
  font-size: 1rem;
  cursor: pointer;
  color: var(--text-color);
}

.back-button:hover {
  background-color: var(--button-hover-color);
}
</style>
