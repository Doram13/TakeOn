<template>
  <div class="container-fluid d-flex h-100 flex-column bg-dark text-light" id="home_container">
    <navbar :user="user"></navbar>
    <div class="row d-flex flex-fill align-items-start">
      <div class="col-sm-8"><journal :journals="journals" @journal-input="saveJournal"/></div>
      <div class="col-sm-4"><commitment :commitments="commitments" class="justify-content-center"/>
      </div>
    </div>
    <div class="row d-flex flex-fill align-items-center">
      <div class="col-sm-3"><questions :questions="questions"/></div>
      <div class="col-sm-9"><answers :answers="answers" @answer-input="saveAnswer"/></div>
    </div>
    <div class="row flex-fill d-flex">
      <div class="col align-self-end">peer</div>
    </div>
  </div>
</template>
<script>
import Questions from '@/components/Questions';
import Journal from '@/components/Journal';
import Answers from '@/components/Answers';
import Commitment from '@/components/Commitment';
import Navbar from '@/components/Navbar';
import GoalsService from '@/api-services/goals.service';
import PostService from '@/api-services/post.service';

export default {
  name: 'Home',
  components: {
    Navbar,
    Journal,
    Questions,
    Answers,
    Commitment,
  },
  methods: {
    saveJournal() {
      PostService.update(this.journals[0].id, this.journals[0]);
    },
    saveAnswer(answer) {
      PostService.update(answer.id, answer);
    },
  },
  data() {
    return {
      user: '',
      questions: [],
      commitments: [],
      journals: [],
      answers: [],
    };
  },
  created() {
    GoalsService.getAll().then((response) => {
      // eslint-disable-next-line no-plusplus
      for (let i = 0; i < response.data.length; i++) {
        if (response.data[i].goalType === 0) {
          this.commitments.push(response.data[i]);
        } else {
          this.questions.push(response.data[i]);
        }
      }
    });
    PostService.getAll().then((response) => {
      // eslint-disable-next-line no-plusplus
      for (let i = 0; i < response.data.length; i++) {
        if (response.data[i].postType === 0) {
          this.journals.push(response.data[i]);
        } else {
          this.answers.push(response.data[i]);
        }
      }
    });
  },
};
</script>
<style scoped>
  #home_container {
    min-height: 90vh;
  }
</style>
