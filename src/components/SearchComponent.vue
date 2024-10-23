<template>
  <div class="conteiner-central">
    <div class="search-container">
      <div class="conteiner-h1">
        <div class="subconteiner-h1">
          <h1 class="title">Explore repositórios no Github.</h1>
        </div>
      </div>
      <div class="search-bar">
        <input
          type="text"
          placeholder="Digite aqui"
          v-model="searchQuery"
          @keyup.enter="searchRepository"
          class="search-input"
        />
        <button @click="searchRepository" class="search-button">
          Pesquisar
        </button>
      </div>
      <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "SearchComponent",
  props: {
    errorMessage: String, // Adicionando prop para a mensagem de erro
  },
  data() {
    return {
      searchQuery: "",
    };
  },
  methods: {
    searchRepository() {
      if (this.searchQuery.trim() !== "") {
        console.log("Evento search emitido com query:", this.searchQuery);
        this.$emit("search", this.searchQuery); // Emitindo o evento
      }
    },
  },
};
</script>


<style scoped>
/* Estilo do componente */
.conteiner-central {
  margin-left: 25.5%;
  margin-bottom: 70px;
  /* border: #04d361 1px solid; */
}

.conteiner-h1 {
  margin-bottom: 20px;
  width: 100%;
  /* border: #04d361 1px solid; */
}

.subconteiner-h1{
    width: 69%;
    /* border: #04d361 1px solid;   */
}

.h1{
    font-size: 48px;
    font-weight: bolder;
    color: var(--title-color);
}

.search-container {
  display: flex;
  flex-direction: column;
  align-items: left;
  margin-top: 50px; /* Espaçamento do topo */
}

.title {
  font-weight: 500;
  margin-bottom: 20px;
  text-align: left;
  color: var(--title-color);
  font-size: 38px;
  font-weight: bolder;
}

.search-bar {
  display: flex;
  align-items: center;
  width: 100%;
  max-width: 700px; /* Largura máxima da barra de pesquisa */
}

.search-input {
  flex: 1;
  padding: 20px;
  font-size: 13px;
  border: 1px solid var(--border-color);
  border-radius: 5px 0 0 5px;
}

.search-button {
  padding: 22px;
  background-color: var(--button-color);
  color: var(--text-color);
  font-size: 12px;
  font-weight: bolder;
  border: none;
  border-radius: 0 5px 5px 0;
  cursor: pointer;
  width: 170px;
}

.search-button:hover {
  background-color: var(--button-hover-color); /* Cor do botão ao passar o mouse */
}

.error-message {
  color: red;
  margin-top: 10px;
  font-size: 14px;
}
</style>
