import { InfoMuridTemplatePage } from './app.po';

describe('InfoMurid App', function() {
  let page: InfoMuridTemplatePage;

  beforeEach(() => {
    page = new InfoMuridTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
