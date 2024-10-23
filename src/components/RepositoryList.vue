<template>
  <div class="repository-list">
    <div v-for="repo in repos" :key="repo.id" class="repository-card" @click="selectRepository(repo)">
      <img :src="repo.avatar" alt="Repo Avatar" class="repo-avatar" />
      <div class="repository-info">
        <h2>{{ repo.name }}</h2>
        <p>{{ repo.description }}</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: 'RepositoryList',
  props: {
    repos: Array
  },
  methods: {
    selectRepository(repo) {
      this.$emit('repository-selected', repo);
    }
  }
}
</script>

<style scoped>
.repository-list {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  margin-left: 25%;
  width: 100%;
}

.repository-card {
  display: flex; /* Para criar um layout flexível */
  align-items: center; /* Centraliza verticalmente os itens */
  background-color: var(--background-color);
  border: 1px solid var(--border-color);
  padding: 10px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
  width: 100%; /* Ocupa 100% da largura do contêiner */
  max-width: 600px; /* Limita a largura máxima */
  margin-bottom: 10px;
  margin-top: 10px;
  height: auto; /* Remove a altura fixa */
  box-sizing: border-box;
}

.repository-card:hover {
  background-color: var(--hover-background-color);
}

.repo-avatar {
  flex-shrink: 0; /* Impede que a imagem encolha */
  width: 50px;
  height: 50px;
  border-radius: 50%;
  margin-right: 10px; /* Espaçamento entre a imagem e o texto */
}

.repository-info {
  display: flex;
  flex-direction: column; /* Alinha o título e a descrição em coluna */
  text-overflow: ellipsis; /* Adiciona "..." quando o texto for muito longo */
  overflow: hidden
}

h2, p {
  margin: 0;
  overflow: hidden;
  text-overflow: ellipsis; /* Adiciona "..." quando o texto for muito longo */
  white-space: nowrap; /* Impede que o texto quebre em várias linhas */
}

h2 {
  font-size: 1.2em;
  margin-bottom: 5px;
  color: var(--title-color);
}

p {
  font-size: 0.9em;
  color: var(--text-color);
}

</style>
