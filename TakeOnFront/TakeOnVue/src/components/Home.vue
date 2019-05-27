<template>
  <div>
    <b-card no-body>
      <b-tabs content-class="mt-3" fill card>
        <b-tab title="Routine"><one-day :text="posts[0].text"/></b-tab>
        <b-tab title="Peer"><one-day :text="posts[1].text"/></b-tab>
        <b-tab title="Journal"><free-style/></b-tab>
      </b-tabs>
    </b-card>
  </div>
</template>
<script>
import OneDayTab from '@/components/OneDayTab';
import PostService from '@/api-services/journal.service';
import FreestyleText from '@/components/FreestyleText';

export default {
  name: 'Home',
  components: {
    'one-day': OneDayTab,
    'free-style': FreestyleText,
  },
  created() {
    PostService.create({ Description: 'this is a journal' });
  },
  data() {
    return {
      posts: [
        { id: 1,
          date: '2019-05-10',
          text: [
            { id: 1, question: 'Question 1', answer: 'daily answer' },
            { id: 2, question: 'Q2', answer: 'daily asdlfkj séodifh aséldk fhaséd hfaosidh fanswer' },
            { id: 3, question: 'question 3', answer: 'daily answer' },
            { id: 4, question: 'question 4', answer: 'daily asdf' },
            { id: 5, question: 'question 5', answer: 'daiasdfasdfly answer' }] },
        { id: 2,
          date: '2019-05-11',
          text: [
            { id: 1, question: 'peerq1', answer: 'daily answer' },
            { id: 2, question: 'questionpeer2', answer: 'daily answer' },
            { id: 3, question: 'questionpee3', answer: 'asdf answer' },
            { id: 4, question: 'questionasdf', answer: 'daily answer' },
            { id: 5, question: 'questionsdf', answer: 'daily answer' }] },
        { id: 3,
          date: '2019-05-12',
          text: [
            { id: 1, question: 'daily question', answer: 'daily answer' },
            { id: 2, question: 'daily question', answer: 'daily answer' },
            { id: 3, question: 'daily question', answer: 'dailyasdfasdf answer' },
            { id: 4, question: 'daily question', answer: 'daily answer' },
            { id: 5, question: 'daily question', answer: 'daily answer' }] },
        { id: 4,
          date: '2019-05-13',
          text: [
            { id: 1, question: 'daily question', answer: 'daily answer' },
            { id: 2, question: 'daily question', answer: 'daily answer' },
            { id: 3, question: 'dailyasdfasdf question', answer: 'daily answer' },
            { id: 4, question: 'daily question', answer: 'daily answer' },
            { id: 5, question: 'daily quasdfasdfestion', answer: 'daily answer' }] },
        { id: 5,
          date: '2019-05-14',
          text: [
            { id: 1, question: 'daily question', answer: 'daily answer' },
            { id: 2, question: 'dailasdfasdfy question', answer: 'daily answer' },
            { id: 3, question: 'daily question', answer: 'daily answer' },
            { id: 4, question: 'daily question', answer: 'daily answer' },
            { id: 5, question: 'daily question', answer: 'dailasdfasdfy answer' }] },
      ],
    };
  },
};
</script>
<style scoped>
</style>
