import { container, singleton } from "tsyringe";
import { bind, FadeService, I18nService, OnInit } from "zes-unity-jslib";
import { getLogger } from "zes-unity-jslib/dist/lib/logger";

@singleton()
export class Root implements OnInit {

    @bind("#fade")
    fadeImage!: CS.UnityEngine.CanvasGroup
    @bind("#label")
    label!: CS.TMPro.TMP_Text;

    async zesOnInit() {
        logger.info("root init");
        const i18n_svc = container.resolve(I18nService);
        const language = CS.Au.App.config.appLanguage;
        const languageBundle = CS.Au.App.config.bundleLanguage;
        await i18n_svc.load(language, `${languageBundle}/i18n-${language}.json`);
        const fade = container.resolve(FadeService);
        fade.canvas = this.fadeImage;
        fade.in();
    }
}

const logger = getLogger(Root.name);

