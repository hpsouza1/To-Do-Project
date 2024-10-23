<template>
  <div class="repository-details" v-if="repo">
    <div class="repository-header">
      <img :src="repo.avatar" alt="Repo Avatar" class="repo-avatar" />
      <div class="repository-info">
        <h1>{{ repo.name }}</h1>
        <p>{{ repo.description }}</p>
      </div>
    </div>
    <div class="repository-kpis">
      <div class="kpi">
        <h2>{{ repo.stars }}</h2>
        <p>Stars</p>
      </div>
      <div class="kpi">
        <h2>{{ repo.forks }}</h2>
        <p>Forks</p>
      </div>
      <div class="kpi">
        <h2>{{ repo.openIssues }}</h2>
        <p>Issues</p>
      </div>
    </div>
    <div class="issue-list">
      <div v-for="issue in issues" :key="issue.id" class="issue-card">
        <a :href="issue.html_url" target="_blank" class="issue-link">
          <div class="issue-info">
            <h3>{{ issue.title }}</h3>
            <p>{{ issue.body }}</p>
          </div>
        </a>
      </div>
    </div>
  </div>
  <p v-else>Loading...</p>
</template>

<script>
import axios from "axios";

export default {
  name: "RepositoryDetails",
  props: {
    repo: Object,
  },
  data() {
    return {
      issues: [],
      errorMessage: null,
    };
  },
  created() {
    console.log('Repository:', this.repo);
    this.fetchIssues();
  },
  methods: {
    async fetchIssues() {
      try {
        if (this.repo && this.repo.name) {
          const response = await axios.get(
            `https://api.github.com/repos/${this.repo.name}/issues`
          );
          this.issues = response.data;
        } else {
          this.errorMessage = "Repositório não encontrado.";
        }
      } catch (error) {
        this.errorMessage = "Erro ao buscar issues.";
        console.error("Erro ao buscar issues:", error);
      }
    },
  },
};
</script>


<style scoped>
.repository-details {
  padding: 20px;
  margin-left: 14%;
  margin-top: 50px;
}

.repository-header {
  display: flex;
  align-items: center;
  margin-bottom: 20px;
}

.repo-avatar {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  margin-right: 20px; /* Espaçamento entre o avatar e o texto */
}

.repository-info {
  flex: 1;
}

.repository-kpis {
  display: flex;
  justify-content: space-between;
  margin-bottom: 20px;
}

.kpi {
  text-align: center;
  flex: 1; /* Faz com que todas as KPIs ocupem o mesmo espaço */
}

.issue-list {
  display: flex;
  flex-wrap: wrap;
  gap: 20px;
}

.issue-card {
  background-color: var(--background-color);
  border: 1px solid var(--border-color);
  padding: 10px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
  width: 100%;
  max-width: 600px;
  margin-bottom: 10px;
  box-sizing: border-box;
  overflow: hidden; /* Garantir que o conteúdo fique dentro do card */
}

.issue-info {
  display: flex;
  flex-direction: column;
}

h3,
p {
  margin: 0;
  overflow: hidden;
  text-overflow: ellipsis; /* Adiciona "..." quando o texto for muito longo */
  white-space: nowrap; /* Impede que o texto quebre em várias linhas */
}

h3 {
  font-size: 1.1em;
  margin-bottom: 5px;
}

p {
  font-size: 0.9em;
  color: var(--text-color);
  max-height: 2.5em; /* Limita a altura da descrição */
}

.issue-link {
  text-decoration: none;
  color: inherit;
}

.issue-card:hover {
  background-color: var(--hover-background-color);
}
</style>
