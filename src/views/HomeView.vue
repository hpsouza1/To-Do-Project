<!-- src/views/HomeView.vue -->
<template>
  <div>
    <SearchComponent @search="fetchRepositories" :errorMessage="errorMessage" />
    <RepositoryList
      v-if="repositories.length && !selectedRepository"
      :repos="repositories"
      @repository-selected="showRepositoryDetails"
    />
  </div>
</template>

<script>
import SearchComponent from "@/components/SearchComponent.vue";
import RepositoryList from "@/components/RepositoryList.vue";
import axios from "axios";

export default {
  name: "HomeView",
  components: {
    SearchComponent,
    RepositoryList,
  },
  data() {
    return {
      repositories: [],
      selectedRepository: null,
      errorMessage: null,
    };
  },
  methods: {
    async fetchRepositories(query) {
      this.errorMessage = null;
      try {
        const response = await axios.get(
          `https://api.github.com/search/repositories?q=${query}`
        );
        if (response.data.items.length > 0) {
          const repo = response.data.items[0]; // Pega apenas o primeiro resultado
          const repository = {
            id: repo.id,
            name: repo.full_name,
            description: repo.description,
            avatar: repo.owner.avatar_url,
            stars: repo.stargazers_count,
            forks: repo.forks_count,
            openIssues: repo.open_issues_count,
          };
          
          // Adiciona o repositório à lista existente
          this.repositories.push(repository);

          // Salva a lista de repositórios atualizada no localStorage
          this.saveRepositoriesToLocalStorage();
        } else {
          this.errorMessage = "Nenhum repositório encontrado para essa busca.";
        }
      } catch (error) {
        this.errorMessage =
          "Erro ao buscar repositórios. Por favor, tente novamente mais tarde.";
      }
    },
    saveRepositoriesToLocalStorage() {
      localStorage.setItem(
        "repositories",
        JSON.stringify(this.repositories)
      );
    },
    showRepositoryDetails(repo) {
      this.$router.push({ name: "repositoryDetails", params: { id: repo.id } });
    },
  },
  mounted() {
    const storedRepositories = JSON.parse(
      localStorage.getItem("repositories")
    );
    if (storedRepositories) {
      this.repositories = storedRepositories;
    }
  },
};
</script>
