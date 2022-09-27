import { container, singleton } from "tsyringe";
import { Bind, FadeService, I18nService, OnInit } from "zes-unity-jslib";

@singleton()
export class Root implements OnInit {

    @Bind("layers/fade/background")
    fadeImage!: CS.UnityEngine.CanvasGroup

    async zesOnInit() {
        console.log("root init");

        const i18n_svc = container.resolve(I18nService);
        const language = CS.Au.App.config.appLanguage;
        const languageBundle = CS.Au.App.config.bundleLanguage;
        await i18n_svc.load(language, `${languageBundle}/i18n_${language}.json`);


        const fade = container.resolve(FadeService);
        fade.speed = 1;
        fade.setFadeImage(this.fadeImage);
        fade.in();
    }
}

